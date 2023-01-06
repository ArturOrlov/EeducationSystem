using EducationSystem.Dto.Material.Test.UserResult;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;
using MapsterMapper;

namespace EducationSystem.Services.Material.Test;

public class UserTestResultService : IUserTestResultService
{
    private readonly IUserTestResultRepository _userTestResultRepository;
    private readonly ITestQuestionRepository _testQuestionRepository;
    private readonly ITestAnswerRepository _testAnswerRepository;
    private readonly ITestRepository _testRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserTestResultService(IUserTestResultRepository userTestResultRepository,
        ITestQuestionRepository testQuestionRepository,
        ITestAnswerRepository testAnswerRepository,
        ITestRepository testRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userTestResultRepository = userTestResultRepository;
        _testQuestionRepository = testQuestionRepository;
        _testAnswerRepository = testAnswerRepository;
        _testRepository = testRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetUserTestResultDto>> GetUserTestResultByIdAsync(int userTestResultId)
    {
        var response = new BaseResponse<GetUserTestResultDto>();

        var userTestResult = await _userTestResultRepository.GetByIdAsync(userTestResultId);

        if (userTestResult == null)
        {
            response.IsError = true;
            response.Description = $"Результат теста с id - {userTestResultId} не найден";
            return response;
        }

        var mapCourse = _mapper.Map<GetUserTestResultDto>(userTestResult);

        response.Data = mapCourse;
        return response;
    }

    public async Task<BaseResponse<List<GetUserTestResultDto>>> GetUserTestResultByPaginationAsync(
        BasePagination request)
    {
        var response = new BaseResponse<List<GetUserTestResultDto>>();

        var userTestResults = _userTestResultRepository.Get(_ => true, request);

        if (!userTestResults.Any())
        {
            return response;
        }

        var mapRoles = _mapper.Map<List<GetUserTestResultDto>>(userTestResults);

        response.Data = mapRoles;
        return response;
    }

    public async Task<BaseResponse<GetUserTestResultDto>> CreateUserTestResultAsync(CreateUserTestResultDto request)
    {
        var response = new BaseResponse<GetUserTestResultDto>();

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} не найден";
            return response;
        }

        var test = await _testRepository.GetByIdAsync(request.TestId);

        if (test == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {request.TestId} не найден";
            return response;
        }

        var userTestResult = _userTestResultRepository.Get(utr => utr.UserId == request.UserId && utr.TestId == request.TestId).FirstOrDefault();

        if (userTestResult != null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} уже проходил тест с id - {request.TestId}";
            return response;
        }

        // Получить все ВОПРОСЫ которые есть у теста
        var questions = _testQuestionRepository.Get(tq => tq.TestId == request.TestId).ToList();

        if (!questions.Any())
        {
            response.IsError = true;
            response.Description = $"Тест-вопросы по id теста - {request.TestId} не найдены";
            return response;
        }

        // Получить все ОТВЕТЫ которые есть у вопроса
        var answers = _testAnswerRepository.Get(ta => questions.Select(b => b.Id).Contains(ta.TestQuestionId)).ToList();

        if (!answers.Any())
        {
            response.IsError = true;
            response.Description = $"Тест-ответы не найдены";
            return response;
        }

        // Получаем кол-во правильных ответов в тесте
        var correctAnswers = answers.Where(ta => ta.IsCorrect).ToList();

        // Получаем кол-во правильных ответов данным пользователем
        var userCorrectAnswers = answers.Where(a => request.SelectedTestAnswerId.Contains(a.Id) && a.IsCorrect).ToList();
            
        // Получаем кол-во неправильных ответов данным пользователем
        var userIncorrectAnswers = answers.Where(a => request.SelectedTestAnswerId.Contains(a.Id) && a.IsCorrect == false).ToList();

        // Подсчёт оценки
        float value = 5f / correctAnswers.Count * (userCorrectAnswers.Count  - userIncorrectAnswers.Count);

        // Защита минимально возможной оценки
        if (value < 2)
        {
            value = 2;
        }
        else
        {
            // Целое число оценки
            var intValue = Math.Truncate(value);
        
            // Значение после запятой оценки
            var decimalValue = value - Math.Truncate(value);

            // Если значение после запятой больше 0.5, то оценка округляется в пользу сдающего
            if (decimalValue >= 0.5)
            {
                intValue += 1;
            }

            value = (float)intValue;
        }
        
        var newUserTestResult = new UserTestResult()
        {
            UserId = request.UserId,
            TestId = request.TestId,
            Value = value
        };

        await _userTestResultRepository.CreateAsync(newUserTestResult);

        var mapUserTestResult = _mapper.Map<GetUserTestResultDto>(newUserTestResult);

        response.Data = mapUserTestResult;
        return response;
    }

    public async Task<BaseResponse<GetUserTestResultDto>> UpdateUserTestResultByIdAsync(int userTestResultId,
        UpdateUserTestResultDto request)
    {
        var response = new BaseResponse<GetUserTestResultDto>();

        var userTestResult = await _userTestResultRepository.GetByIdAsync(userTestResultId);

        if (userTestResult == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {userTestResultId} не найден";
            return response;
        }

        if (request.Value != userTestResult.Value)
        {
            if (request.Value <= 1 || request.Value > 5)
            {
                response.IsError = true;
                response.Description = "Оценка должна быть в предела 2 и 5";
                return response;
            }

            userTestResult.Value = request.Value;
        }

        userTestResult.UpdatedAt = DateTime.Now;
        await _userTestResultRepository.UpdateAsync(userTestResult);

        var mapSubject = _mapper.Map<GetUserTestResultDto>(userTestResult);

        response.Data = mapSubject;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteUserTestResultByIdAsync(int userTestResultId)
    {
        var response = new BaseResponse<string>();

        var userTestResult = await _userTestResultRepository.GetByIdAsync(userTestResultId);

        if (userTestResult == null)
        {
            response.IsError = true;
            response.Description = $"Результат теста с id - {userTestResultId} не найден";
            return response;
        }

        await _userTestResultRepository.DeleteAsync(userTestResult);

        response.Data = "Удалено";
        return response;
    }
}