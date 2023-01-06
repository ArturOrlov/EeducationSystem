using EducationSystem.Dto.Material.Test.Answer;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Test;

public interface ITestAnswerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testAnswerId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestAnswerDto>> GetTestAnswerByIdAsync(int testAnswerId);
    
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
    /// <param name="testAnswerId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetTestAnswerDto>> UpdateTestAnswerByIdAsync(int testAnswerId, UpdateTestAnswerDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testAnswerId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteTestAnswerByIdAsync(int testAnswerId);
}