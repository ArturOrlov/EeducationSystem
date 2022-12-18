using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface ITestAnswerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestAnswerDto>> GetTestAnswerByIdAsync(int testId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetTestAnswerDto>>> GetTestAnswerByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestAnswerDto>> CreateTestAnswerAsync(CreateTestAnswerDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestAnswerDto>> UpdateTestAnswerByIdAsync(int testId, UpdateTestAnswerDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteTestAnswerByIdAsync(int testId);
}