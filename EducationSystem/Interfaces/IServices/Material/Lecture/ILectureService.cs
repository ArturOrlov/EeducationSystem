using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Material.Lecture;

public interface ILectureService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lectureId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLectureDto>> GetLectureByIdAsync(int lectureId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetLectureDto>>> GetLectureByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLectureDto>> CreateLectureAsync(CreateLectureDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lectureId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetLectureDto>> UpdateLectureByIdAsync(int lectureId, UpdateLectureDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lectureId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteLectureByIdAsync(int lectureId);
}