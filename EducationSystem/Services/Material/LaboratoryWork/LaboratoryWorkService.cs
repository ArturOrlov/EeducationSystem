using EducationSystem.Dto.Materail.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;

namespace EducationSystem.Services.Material.LaboratoryWork;

public class LaboratoryWorkService : ILaboratoryWorkService
{
    private readonly ILaboratoryWorkRepository _laboratoryWorkRepository;

    public LaboratoryWorkService(ILaboratoryWorkRepository laboratoryWorkRepository)
    {
        _laboratoryWorkRepository = laboratoryWorkRepository;
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> GetLaboratoryWorkByIdAsync(int laboratoryWorkId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetLaboratoryWorkDto>>> GetLaboratoryWorkByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> CreateLaboratoryWorkAsync(CreateLaboratoryWorkDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> UpdateLaboratoryWorkByIdAsync(int laboratoryWorkId, UpdateLaboratoryWorkDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteLaboratoryWorkByIdAsync(int laboratoryWorkId)
    {
        throw new NotImplementedException();
    }
}