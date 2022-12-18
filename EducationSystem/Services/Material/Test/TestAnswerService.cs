using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;

namespace EducationSystem.Services.Material.Test;

public class TestAnswerService : ITestAnswerService
{
    private readonly ITestAnswerRepository _testAnswerRepository;

    public TestAnswerService(ITestAnswerRepository testAnswerRepository)
    {
        _testAnswerRepository = testAnswerRepository;
    }

    public async Task<BaseResponse<GetTestAnswerDto>> GetTestAnswerByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetTestAnswerDto>>> GetTestAnswerByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestAnswerDto>> CreateTestAnswerAsync(CreateTestAnswerDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetTestAnswerDto>> UpdateTestAnswerByIdAsync(int testId, UpdateTestAnswerDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteTestAnswerByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }
}