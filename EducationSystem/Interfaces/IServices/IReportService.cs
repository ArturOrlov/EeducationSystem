using EducationSystem.Dto.Report;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices;

public interface IReportService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<ResponseUserGpa>> GetUserGpa(UserPerformanceReport request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<ResponseUserPerformance>> GetUserPerformance(UserPerformanceReport request);
}