using EducationSystem.Dto.Material.LaboratoryWork;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.LaboratoryWork;

public interface IUserLaboratoryWorkService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLaboratoryWorkId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLaboratoryWorkDto>> GetUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetUserLaboratoryWorkDto>>> GetUserLaboratoryWorkByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLaboratoryWorkDto>> CreateUserLaboratoryWorkAsync(CreateUserLaboratoryWorkDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLaboratoryWorkId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLaboratoryWorkDto>> UpdateUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId, UpdateUserLaboratoryWorkDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLaboratoryWorkId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId);
}