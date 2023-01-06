using EducationSystem.Dto.Material.Test.UserResult;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface IUserTestResultService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userTestResultId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserTestResultDto>> GetUserTestResultByIdAsync(int userTestResultId);
    
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
    /// <param name="userTestResultId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserTestResultDto>> UpdateUserTestResultByIdAsync(int userTestResultId, UpdateUserTestResultDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userTestResultId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteUserTestResultByIdAsync(int userTestResultId);
}