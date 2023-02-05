using EducationSystem.Dto.Course;
using EducationSystem.Dto.Identity.User;
using EducationSystem.Dto.Report;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels;
using EducationSystem.Entities.DbModels.Education;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices;

namespace EducationSystem.Services;

public class ReportService : IReportService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ILaboratoryWorkRepository _laboratoryWorkRepository;
    private readonly IUserLaboratoryWorkRepository _userLaboratoryWorkRepository;
    private readonly ITestRepository _testRepository;
    private readonly IUserTestResultRepository _userTestResultRepository;

    public ReportService(IUserRepository userRepository,
        IUserInfoRepository userInfoRepository, 
        ICourseRepository courseRepository, 
        ILaboratoryWorkRepository laboratoryWorkRepository,
        IUserLaboratoryWorkRepository userLaboratoryWorkRepository, 
        ITestRepository testRepository, 
        IUserTestResultRepository userTestResultRepository)
    {
        _userRepository = userRepository;
        _userInfoRepository = userInfoRepository;
        _courseRepository = courseRepository;
        _laboratoryWorkRepository = laboratoryWorkRepository;
        _userLaboratoryWorkRepository = userLaboratoryWorkRepository;
        _testRepository = testRepository;
        _userTestResultRepository = userTestResultRepository;
    }

    public async Task<BaseResponse<ResponseUserGpa>> GetUserGpa(UserPerformanceReport request)
    {
        var response = new BaseResponse<ResponseUserGpa>();

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} не найден";
            return response;
        }

        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {request.CourseId} не найден";
            return response;
        }

        // Получаем средний балл
        var userLabs = GetUserPerfForLabs(request.CourseId, request.UserId);
        var labSum = userLabs.Select(ul => ul.UserValue).Sum();

        // Получаем оценки за тесты
        var userTests = GetUserPerfForTests(request.CourseId, request.UserId);
        var testSum = userTests.Select(ul => ul.UserValue).Sum();

        var gpa = (labSum + testSum) / (userLabs.Count + userTests.Count);

        // Подготавливаем общие данные
        var generalPerformanceData = await PrepareGeneralPerformanceData(user, course);

        var responseUserPerformance = new ResponseUserGpa()
        {
            User = generalPerformanceData.Item1,
            Course = generalPerformanceData.Item2,
            UserGpa = gpa
        };

        response.Data = responseUserPerformance;
        return response;
    }

    public async Task<BaseResponse<ResponseUserPerformance>> GetUserPerformance(UserPerformanceReport request)
    {
        var response = new BaseResponse<ResponseUserPerformance>();

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} не найден";
            return response;
        }

        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {request.CourseId} не найден";
            return response;
        }

        // Получаем оценки за лабораторные работы
        var userLabs = GetUserPerfForLabs(request.CourseId, request.UserId);

        // Получаем оценки за тесты
        var userTests = GetUserPerfForTests(request.CourseId, request.UserId);

        // Подготавливаем общие данные
        var generalPerformanceData = await PrepareGeneralPerformanceData(user, course);

        var responseUserPerformance = new ResponseUserPerformance()
        {
            User = generalPerformanceData.Item1,
            Course = generalPerformanceData.Item2,
            LaboratoryWorks = userLabs,
            Tests = userTests
        };

        response.Data = responseUserPerformance;
        return response;
    }

    private List<UserPerformanceData> GetUserPerfForLabs(int courseId, int userId)
    {
        var laboratoryWorks = _laboratoryWorkRepository.Get(lw => lw.CourseId == courseId).ToList();
        var userLabs = new List<UserPerformanceData>();

        if (laboratoryWorks.Any())
        {
            var userLaboratoryWorks = _userLaboratoryWorkRepository.Get(ulw =>
                    laboratoryWorks.Select(lw => lw.Id).Contains(ulw.LaboratoryWorkId) && ulw.UserId == userId)
                .ToList();

            if (userLaboratoryWorks.Any())
            {
                userLabs.AddRange(userLaboratoryWorks.Select(ulw => new UserPerformanceData()
                {
                    Id = laboratoryWorks.FirstOrDefault(lw => lw.Id == ulw.LaboratoryWorkId)!.Id,
                    Name = laboratoryWorks.FirstOrDefault(lw => lw.Id == ulw.LaboratoryWorkId)!.Name,
                    UserValue = ulw.Value ?? 0
                }));
            }
        }

        return userLabs;
    }

    private List<UserPerformanceData> GetUserPerfForTests(int courseId, int userId)
    {
        var tests = _testRepository.Get(t => t.CourseId == courseId).ToList();
        var userTests = new List<UserPerformanceData>();

        if (tests.Any())
        {
            var userTestResult = _userTestResultRepository.Get(utr =>
                    tests.Select(lw => lw.Id).Contains(utr.TestId) && utr.UserId == userId)
                .ToList();

            if (userTestResult.Any())
            {
                userTests.AddRange(userTestResult.Select(ulw => new UserPerformanceData()
                {
                    Id = tests.FirstOrDefault(lw => lw.Id == ulw.TestId)!.Id,
                    Name = tests.FirstOrDefault(lw => lw.Id == ulw.TestId)!.Name,
                    UserValue = ulw.Value
                }));
            }
        }

        return userTests;
    }

    private async Task<(UserFio, GetCourseDto)> PrepareGeneralPerformanceData(User user, Course course)
    {
        var userInfo = await _userInfoRepository.GetByUserId(user.Id);

        var userFio = new UserFio()
        {
            Id = user.Id,
        };

        if (userInfo != null)
        {
            userFio.FirstName = userInfo.FirstName;
            userFio.LastName = userInfo.LastName;
            userFio.Patronymic = userInfo.Patronymic;
        }

        var courseDto = new GetCourseDto()
        {
            Id = course.Id,
            Name = course.Name,
        };

        return (userFio, courseDto);
    }
}