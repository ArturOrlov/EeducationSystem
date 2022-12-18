using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;

namespace EducationSystem.Services.Material.Test;

public class TestQuestionService : ITestQuestionService
{
    private readonly ITestQuestionRepository _testQuestionRepository;

    public TestQuestionService(ITestQuestionRepository testQuestionRepository)
    {
        _testQuestionRepository = testQuestionRepository;
    }

    public async Task<BaseResponse<GetTestQuestionDto>> GetTestQuestionByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetTestQuestionDto>>> GetTestQuestionByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestQuestionDto>> CreateTestQuestionAsync(CreateTestQuestionDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestQuestionDto>> UpdateTestQuestionByIdAsync(int testId, UpdateTestQuestionDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteTestQuestionByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }
}