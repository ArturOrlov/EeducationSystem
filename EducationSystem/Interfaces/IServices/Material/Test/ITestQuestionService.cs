using EducationSystem.Dto.Material.Test.Question;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface ITestQuestionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testQuestionId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestQuestionDto>> GetTestQuestionByIdAsync(int testQuestionId);
    
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
    /// <param name="testQuestionId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestQuestionDto>> UpdateTestQuestionByIdAsync(int testQuestionId, UpdateTestQuestionDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testQuestionId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteTestQuestionByIdAsync(int testQuestionId);
}