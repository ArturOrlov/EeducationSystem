using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material;

namespace EducationSystem.Services.Material;

public class TestService : ITestService
{
    private readonly ITestAnswerRepository _testAnswerRepository;
    private readonly ITestHeadRepository _testHeadRepository;
    private readonly ITestQuestionRepository _testQuestionRepository;
    private readonly IUserTestAnswerRepository _userTestAnswerRepository;
    private readonly IUserTestQuestionRepository _userTestQuestionRepository;

    public TestService(ITestAnswerRepository testAnswerRepository,
        ITestHeadRepository testHeadRepository,
        ITestQuestionRepository testQuestionRepository,
        IUserTestAnswerRepository userTestAnswerRepository, 
        IUserTestQuestionRepository userTestQuestionRepository)
    {
        _testAnswerRepository = testAnswerRepository;
        _testHeadRepository = testHeadRepository;
        _testQuestionRepository = testQuestionRepository;
        _userTestAnswerRepository = userTestAnswerRepository;
        _userTestQuestionRepository = userTestQuestionRepository;
    }

    public async Task<BaseResponse<GetTestDto>> GetTestByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetTestDto>>> GetTestByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestDto>> CreateTestAsync(CreateTestDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestDto>> UpdateTestByIdAsync(int testId, UpdateTestDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteTestByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }
}