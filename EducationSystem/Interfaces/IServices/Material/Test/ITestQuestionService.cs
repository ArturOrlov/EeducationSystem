using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface ITestQuestionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestQuestionDto>> GetTestQuestionByIdAsync(int testId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetTestQuestionDto>>> GetTestQuestionByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestQuestionDto>> CreateTestQuestionAsync(CreateTestQuestionDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestQuestionDto>> UpdateTestQuestionByIdAsync(int testId, UpdateTestQuestionDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteTestQuestionByIdAsync(int testId);
}