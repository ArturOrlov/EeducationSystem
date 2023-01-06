using EducationSystem.Dto.Material.Test.Answer;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;
using MapsterMapper;

namespace EducationSystem.Services.Material.Test;

public class TestAnswerService : ITestAnswerService
{
    private readonly ITestAnswerRepository _testAnswerRepository;
    private readonly ITestQuestionRepository _testQuestionRepository;
    private readonly IMapper _mapper;

    public TestAnswerService(ITestAnswerRepository testAnswerRepository,
        ITestQuestionRepository testQuestionRepository,
        IMapper mapper)
    {
        _testAnswerRepository = testAnswerRepository;
        _testQuestionRepository = testQuestionRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetTestAnswerDto>> GetTestAnswerByIdAsync(int testAnswerId)
    {
        var response = new BaseResponse<GetTestAnswerDto>();

        var testAnswer = await _testAnswerRepository.GetByIdAsync(testAnswerId);
        
        if (testAnswer == null)
        {
            response.IsError = true;
            response.Description = $"Тест-ответ с id - {testAnswerId} не найден";
            return response;
        }

        var mapCourse = _mapper.Map<GetTestAnswerDto>(testAnswer);

        response.Data = mapCourse;
        return response;
    }

    public async Task<BaseResponse<List<GetTestAnswerDto>>> GetTestAnswerByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetTestAnswerDto>>();

        var testAnswers = _testAnswerRepository.Get(_ => true, request);

        if (!testAnswers.Any())
        {
            return response;
        }

        var mapRoles = _mapper.Map<List<GetTestAnswerDto>>(testAnswers);

        response.Data = mapRoles;
        return response;
    }

    public async Task<BaseResponse<GetTestAnswerDto>> CreateTestAnswerAsync(CreateTestAnswerDto request)
    {
        var response = new BaseResponse<GetTestAnswerDto>();

        var checkTestQuestion = await _testQuestionRepository.GetByIdAsync(request.TestQuestionId);

        if (checkTestQuestion == null)
        {
            response.IsError = true;
            response.Description = $"Тест-вопрос с id - {request.TestQuestionId} не найден";
            return response;
        }
        
        if (string.IsNullOrEmpty(request.QuestionAnswer))
        {
            response.IsError = true;
            response.Description = "Описание ответа отсутствует";
            return response;
        }

        var newTestAnswer = _mapper.Map<TestAnswer>(request);
        
        await _testAnswerRepository.CreateAsync(newTestAnswer);
        
        var mapTestAnswer = _mapper.Map<GetTestAnswerDto>(newTestAnswer);
        
        response.Data = mapTestAnswer;
        return response;
    }

    public async Task<BaseResponse<GetTestAnswerDto>> UpdateTestAnswerByIdAsync(int testAnswerId, UpdateTestAnswerDto request)
    {
        var response = new BaseResponse<GetTestAnswerDto>();
        
        var testAnswer = await _testAnswerRepository.GetByIdAsync(testAnswerId);

        if (testAnswer == null)
        {
            response.IsError = true;
            response.Description = $"Вопрос-ответ с id - {testAnswerId} не найден";
            return response;
        }

        if (request.TestQuestionId != testAnswerId)
        {
            var newTestQuestions = await _testAnswerRepository.GetByIdAsync(request.TestQuestionId);

            if (newTestQuestions == null)
            {
                response.IsError = true;
                response.Description = $"Новый вопрос-ответ с id - {request.TestQuestionId} не найден";
                return response;  
            }
        }

        if (!string.IsNullOrEmpty(request.QuestionAnswer) && request.QuestionAnswer != testAnswer.QuestionAnswer)
        {
            testAnswer.QuestionAnswer = request.QuestionAnswer;
        }

        if (request.IsCorrect != testAnswer.IsCorrect)
        {
            testAnswer.IsCorrect = request.IsCorrect;
        }

        testAnswer.UpdatedAt = DateTime.Now;
        await _testAnswerRepository.UpdateAsync(testAnswer);
        
        var mapSubject = _mapper.Map<GetTestAnswerDto>(testAnswer);
        
        response.Data = mapSubject;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteTestAnswerByIdAsync(int testAnswerId)
    {
        var response = new BaseResponse<string>();

        var testAnswer = await _testAnswerRepository.GetByIdAsync(testAnswerId);

        if (testAnswer == null)
        {
            response.IsError = true;
            response.Description = $"Тест-ответ с id - {testAnswerId} не найден";
            return response;
        }

        await _testAnswerRepository.DeleteAsync(testAnswer);

        response.Data = "Удалено";
        return response;
    }
}