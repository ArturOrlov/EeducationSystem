using EducationSystem.Dto;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices;

public interface IDictionarySettingService
{
    Task<BaseResponse<ApplicationSettingResponseDto>> AddSetting(ApplicationSettingDto settingDto);
    Task<BaseResponse<ApplicationSettingResponseDto>> UpdateSetting(int settingId, ApplicationSettingDto settingDto);
    Task<BaseResponse<ApplicationSettingResponseDto>> GetSetting(int settingId);
    Task<BaseResponse<BasePaginationResponse<ApplicationSettingResponseDto>>> GetPagedSettings(BasePagination pagination);
    Task<BaseResponse<string>> DeleteSetting(int settingId);
}