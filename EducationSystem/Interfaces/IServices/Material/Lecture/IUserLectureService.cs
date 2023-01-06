using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Lecture;

public interface IUserLectureService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLectureId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLectureDto>> GetUserLectureByIdAsync(int userLectureId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetUserLectureDto>>> GetUserLectureByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLectureDto>> CreateUserLectureAsync(CreateUserLectureDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLectureId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserLectureDto>> UpdateUserLectureByIdAsync(int userLectureId, UpdateUserLectureDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLectureId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteUserLectureByIdAsync(int userLectureId);
}