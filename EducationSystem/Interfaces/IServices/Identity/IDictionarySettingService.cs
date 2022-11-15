using EducationSystem.Dto;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Identity;

public interface IDictionarySettingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingDto"></param>
    /// <returns></returns>
    Task<BaseResponse<ApplicationSettingResponseDto>> AddSettingAsync(ApplicationSettingDto settingDto);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingId"></param>
    /// <param name="settingDto"></param>
    /// <returns></returns>
    Task<BaseResponse<ApplicationSettingResponseDto>> UpdateSettingAsync(int settingId, ApplicationSettingDto settingDto);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingId"></param>
    /// <returns></returns>
    Task<BaseResponse<ApplicationSettingResponseDto>> GetSettingAsync(int settingId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<BaseResponse<BasePaginationResponse<ApplicationSettingResponseDto>>> GetPagedSettingsAsync(BasePagination pagination);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteSettingAsync(int settingId);
}