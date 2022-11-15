using EducationSystem.Dto;

namespace EducationSystem.Interfaces.IServices.Identity;

/// <summary>
/// Сервис глобальных настроек приложения (сервис получения настроек)
/// </summary>
public interface ISettingService
{
    Task<int> GetInt(string settingName);
    Task<string> GetString(string settingName);
    Task<EmailSettings> GetEmailSendData();
}