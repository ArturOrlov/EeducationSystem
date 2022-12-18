using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface IUserTestResultService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserTestResultDto>> GetUserTestResultByIdAsync(int testId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetUserTestResultDto>>> GetUserTestResultByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserTestResultDto>> CreateUserTestResultAsync(CreateUserTestResultDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserTestResultDto>> UpdateUserTestResultByIdAsync(int testId, UpdateUserTestResultDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteUserTestResultByIdAsync(int testId);
}