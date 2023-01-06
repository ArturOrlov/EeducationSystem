using EducationSystem.Dto.Material.Test.Question;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Enums;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Material.Test;
using MapsterMapper;

namespace EducationSystem.Services.Material.Test;

public class TestQuestionService : ITestQuestionService
{
    private readonly ITestQuestionRepository _testQuestionRepository;
    private readonly ITestRepository _testRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public TestQuestionService(ITestQuestionRepository testQuestionRepository, 
        ITestRepository testRepository, 
        IFileService fileService, 
        IMapper mapper)
    {
        _testQuestionRepository = testQuestionRepository;
        _testRepository = testRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetTestQuestionDto>> GetTestQuestionByIdAsync(int testQuestionId)
    {
        var response = new BaseResponse<GetTestQuestionDto>();

        var testQuestion = await _testQuestionRepository.GetByIdAsync(testQuestionId);
        
        if (testQuestion == null)
        {
            response.IsError = true;
            response.Description = $"Тест-вопрос с id - {testQuestionId} не найден";
            return response;
        }

        var mapCourse = _mapper.Map<GetTestQuestionDto>(testQuestion);

        response.Data = mapCourse;
        return response;
    }

    public async Task<BaseResponse<List<GetTestQuestionDto>>> GetTestQuestionByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetTestQuestionDto>>();

        var testQuestions = _testQuestionRepository.Get(_ => true, request);

        if (!testQuestions.Any())
        {
            return response;
        }

        var mapRoles = _mapper.Map<List<GetTestQuestionDto>>(testQuestions);

        response.Data = mapRoles;
        return response;
    }

    public async Task<BaseResponse<GetTestQuestionDto>> CreateTestQuestionAsync(CreateTestQuestionDto request)
    {
        var response = new BaseResponse<GetTestQuestionDto>();

        var test = await _testRepository.GetByIdAsync(request.TestId);
        
        if (test == null)
        {
            response.IsError = true;
            response.Description = $"Тест с id - {request.TestId} не найден";
            return response;
        }
        
        if (string.IsNullOrEmpty(request.QuestionDescription))
        {
            response.IsError = true;
            response.Description = "Описание теста отсутствует";
            return response;
        }

        var newTestQuestion = _mapper.Map<TestQuestion>(request);
        
        if (request.Image != null)
        {
            var filePath = await _fileService.SaveFile(request.Image, AppFileType.Image);
            newTestQuestion.Image = filePath;
        }
        else
        {
            newTestQuestion.Image = string.Empty;
        }
        
        await _testQuestionRepository.CreateAsync(newTestQuestion);
        
        var mapTest = _mapper.Map<GetTestQuestionDto>(newTestQuestion);
        
        response.Data = mapTest;
        return response;
    }

    public async Task<BaseResponse<GetTestQuestionDto>> UpdateTestQuestionByIdAsync(int testQuestionId, UpdateTestQuestionDto request)
    {
        var response = new BaseResponse<GetTestQuestionDto>();
        
        var testQuestion = await _testQuestionRepository.GetByIdAsync(testQuestionId);

        if (testQuestion == null)
        {
            response.IsError = true;
            response.Description = $"Тест-вопрос с id - {testQuestionId} не найден";
            return response;
        }

        if (request.TestId != testQuestion.TestId)
        {
            var newTestQuestions = await _testQuestionRepository.GetByIdAsync(request.TestId);

            if (newTestQuestions == null)
            {
                response.IsError = true;
                response.Description = $"Тест с id - {request.TestId} не найден";
                return response;  
            }

            testQuestion.TestId = request.TestId;
        }

        if (!string.IsNullOrEmpty(request.QuestionDescription) && request.QuestionDescription != testQuestion.QuestionDescription)
        {
            testQuestion.QuestionDescription = request.QuestionDescription;
        }

        if (request.Image != null)
        {
            _fileService.DeleteFile(testQuestion.Image);
            var filePath = await _fileService.SaveFile(request.Image, AppFileType.Image);
            testQuestion.Image = filePath;
        }

        testQuestion.UpdatedAt = DateTime.Now;
        await _testQuestionRepository.UpdateAsync(testQuestion);
        
        var mapSubject = _mapper.Map<GetTestQuestionDto>(testQuestion);
        
        response.Data = mapSubject;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteTestQuestionByIdAsync(int testQuestionId)
    {
        var response = new BaseResponse<string>();

        var testQuestion = await _testQuestionRepository.GetByIdAsync(testQuestionId);

        if (testQuestion == null)
        {
            response.IsError = true;
            response.Description = $"Тест-вопрос теста с id - {testQuestionId} не найден";
            return response;
        }
        
        if (!string.IsNullOrEmpty(testQuestion.Image))
        {
            _fileService.DeleteFile(testQuestion.Image);
        }

        await _testQuestionRepository.DeleteAsync(testQuestion);

        response.Data = "Удалено";
        return response;
    }
}