using EducationSystem.Dto.Materail.LaboratoryWork;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.LaboratoryWork;

public interface ILaboratoryWorkService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laboratoryWorkId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLaboratoryWorkDto>> GetLaboratoryWorkByIdAsync(int laboratoryWorkId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetLaboratoryWorkDto>>> GetLaboratoryWorkByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLaboratoryWorkDto>> CreateLaboratoryWorkAsync(CreateLaboratoryWorkDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laboratoryWorkId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLaboratoryWorkDto>> UpdateLaboratoryWorkByIdAsync(int laboratoryWorkId, UpdateLaboratoryWorkDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laboratoryWorkId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteLaboratoryWorkByIdAsync(int laboratoryWorkId);
}