using EducationSystem.Dto.Course;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices;

public interface ICourseService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetCourseDto>> GetCourseByIdAsync(int courseId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    Task<BaseResponse<CourseWithMaterialsDto>> GetCourseWithMaterialsAsync(int courseId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetCourseDto>>> GetCourseByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetCourseDto>> CreateCourseAsync(CreateCourseDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetCourseDto>> UpdateCourseByIdAsync(int courseId, UpdateCourseDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteCourseByIdAsync(int courseId);
}