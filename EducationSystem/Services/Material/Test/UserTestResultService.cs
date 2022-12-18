using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices.Material.Test;

namespace EducationSystem.Services.Material.Test;

public class UserTestResultService : IUserTestResultService
{
    private readonly IUserTestResultRepository _userTestResultRepository;

    public UserTestResultService(IUserTestResultRepository userTestResultRepository)
    {
        _userTestResultRepository = userTestResultRepository;
    }

    public async Task<BaseResponse<GetUserTestResultDto>> GetUserTestResultByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetUserTestResultDto>>> GetUserTestResultByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserTestResultDto>> CreateUserTestResultAsync(CreateUserTestResultDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserTestResultDto>> UpdateUserTestResultByIdAsync(int testId, UpdateUserTestResultDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteUserTestResultByIdAsync(int testId)
    {
        throw new NotImplementedException();
    }
}