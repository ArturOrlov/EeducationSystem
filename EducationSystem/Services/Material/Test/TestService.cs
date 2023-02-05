using EducationSystem.Dto.Material.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;
using MapsterMapper;

namespace EducationSystem.Services.Material.Test;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public TestService(ITestRepository testRepository, 
        ICourseRepository courseRepository,
        IMapper mapper)
    {
        _testRepository = testRepository;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetTestDto>> GetTestByIdAsync(int testId)
    {
        var response = new BaseResponse<GetTestDto>();

        var test = await _testRepository.GetByIdAsync(testId);
        
        if (test == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {testId} не найден";
            return response;
        }

        var mapCourse = _mapper.Map<GetTestDto>(test);

        response.Data = mapCourse;
        return response;
    }

    public async Task<BaseResponse<List<GetTestDto>>> GetTestByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetTestDto>>();

        var tests = _testRepository.Get(_ => true, request);

        if (!tests.Any())
        {
            return response;
        }

        var mapTests = _mapper.Map<List<GetTestDto>>(tests);

        response.Data = mapTests;
        return response;
    }

    public async Task<BaseResponse<GetTestDto>> CreateTestAsync(CreateTestDto request)
    {
        var response = new BaseResponse<GetTestDto>();

        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {request.CourseId} не найден";
            return response;
        }
        
        if (string.IsNullOrEmpty(request.Name))
        {
            response.IsError = true;
            response.Description = "Имя теста отсутствует";
            return response;
        }

        var checkTestName = _testRepository.Get(t => t.Name == request.Name).FirstOrDefault();

        if (checkTestName != null)
        {
            response.IsError = true;
            response.Description = "Тест с таким имением уже существует";
            return response;
        }
        
        if (string.IsNullOrEmpty(request.Description))
        {
            response.IsError = true;
            response.Description = "Описание теста отсутствует";
            return response;
        }

        var newTest = _mapper.Map<Entities.DbModels.Material.Test.Test>(request);
        
        await _testRepository.CreateAsync(newTest);
        
        var mapTest = _mapper.Map<GetTestDto>(newTest);
        
        response.Data = mapTest;
        return response;
    }

    public async Task<BaseResponse<GetTestDto>> UpdateTestByIdAsync(int testId, UpdateTestDto request)
    {
        var response = new BaseResponse<GetTestDto>();
        
        var test = await _testRepository.GetByIdAsync(testId);

        if (test == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {testId} не найден";
            return response;
        }
        
        if (!string.IsNullOrEmpty(request.Name) && request.Name != test.Name)
        {
            var checkTestName = _testRepository.Get(t => t.Name == request.Name).FirstOrDefault();

            if (checkTestName != null)
            {
                response.IsError = true;
                response.Description = "Тест с таким имением уже существует";
                return response;
            }
            
            test.Name = request.Name;
        }
        
        if (!string.IsNullOrEmpty(request.Description) && request.Description != test.Description)
        {
            test.Description = request.Description;
        }

        if (request.CourseId != test.CourseId)
        {
            var newTestQuestions = await _testRepository.GetByIdAsync(request.CourseId);

            if (newTestQuestions == null)
            {
                response.IsError = true;
                response.Description = $"Новый вопрос-ответ с id - {request.CourseId} не найден";
                return response;  
            }
            
            test.CourseId = request.CourseId;
        }

        if (request.IsActive != test.IsActive)
        {
            test.IsActive = request.IsActive;
        }

        test.UpdatedAt = DateTime.Now;
        await _testRepository.UpdateAsync(test);
        
        var mapTest = _mapper.Map<GetTestDto>(test);
        
        response.Data = mapTest;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteTestByIdAsync(int testId)
    {
        var response = new BaseResponse<string>();

        var test = await _testRepository.GetByIdAsync(testId);

        if (test == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {testId} не найден";
            return response;
        }

        await _testRepository.DeleteAsync(test);

        response.Data = "Удалено";
        return response;
    }
}