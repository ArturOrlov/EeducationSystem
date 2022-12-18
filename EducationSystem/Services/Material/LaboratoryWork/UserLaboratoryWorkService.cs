using EducationSystem.Dto.Materail.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;

namespace EducationSystem.Services.Material.LaboratoryWork;

public class UserLaboratoryWorkService : IUserLaboratoryWorkService
{
    private readonly IUserLaboratoryWorkRepository _userLaboratoryWorkRepository;

    public UserLaboratoryWorkService(IUserLaboratoryWorkRepository userLaboratoryWorkRepository)
    {
        _userLaboratoryWorkRepository = userLaboratoryWorkRepository;
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> GetUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetUserLaboratoryWorkDto>>> GetUserLaboratoryWorkByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> CreateUserLaboratoryWorkAsync(CreateUserLaboratoryWorkDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> UpdateUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId, UpdateUserLaboratoryWorkDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId)
    {
        throw new NotImplementedException();
    }
}