using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material;

public interface ITestService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestDto>> GetTestByIdAsync(int testId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetTestDto>>> GetTestByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestDto>> CreateTestAsync(CreateTestDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestDto>> UpdateTestByIdAsync(int testId, UpdateTestDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteTestByIdAsync(int testId);
}