using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material;
using EducationSystem.Interfaces.IServices.Material.Test;

namespace EducationSystem.Services.Material.Test;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;

    public TestService(ITestRepository testRepository)
    {
        _testRepository = testRepository;
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