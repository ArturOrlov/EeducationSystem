using EducationSystem.Constants;
using EducationSystem.Dto;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Dictionaries;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using MapsterMapper;

namespace EducationSystem.Services.Identity;

public class SettingService : IDictionarySettingService, ISettingService
{
    private readonly IApplicationSettingsRepository _applicationSettingsRepository;
    private readonly IMapper _mapper;

    public SettingService(IApplicationSettingsRepository applicationSettingsRepository,
        IMapper mapper)
    {
        _applicationSettingsRepository = applicationSettingsRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<ApplicationSettingResponseDto>> AddSettingAsync(ApplicationSettingDto settingDto)
    {
        var result = new BaseResponse<ApplicationSettingResponseDto>(null);

        if (settingDto == null || string.IsNullOrWhiteSpace(settingDto.Name))
        {
            result.Description = "Необходимо передать обязательный параметр Name";
            return result;
        }
            
        // Проверить есть ли элемент с таким Name
        var existedSetting = await _applicationSettingsRepository.GetByNameAsync(settingDto.Name);
        if (existedSetting != null)
        {
            result.Description = "Такая настройка уже существует";
            return result;
        }
            
        // Добавить элемент
        var newSetting = _mapper.Map<ApplicationSettings>(settingDto);
        await _applicationSettingsRepository.CreateAsync(newSetting);

        result.Data = _mapper.Map<ApplicationSettingResponseDto>(newSetting);
        return result;
    }

    public async Task<BaseResponse<ApplicationSettingResponseDto>> UpdateSettingAsync(int settingId, ApplicationSettingDto settingDto)
    {
        var result = new BaseResponse<ApplicationSettingResponseDto>(null);
            
        // Получить существующую настройку
        var existedIdSetting = await _applicationSettingsRepository.GetByIdAsync(settingId);

        if (existedIdSetting == null)
        {
            result.Description = $"Настрйоки с Id = [{settingId}] не найдены";
            return result;
        }

        if (settingDto?.Name != null)
        {
            var existedNameSetting = await _applicationSettingsRepository.GetByNameAsync(settingDto.Name);
            if (existedNameSetting != null && existedNameSetting.Id != existedIdSetting.Id)
            {
                result.Description = "Нельзя изменить имя настройки, настройка с таким именем уже существует";
                return result;
            }
        }
            
        // Изменить настройку
        _mapper.Map(settingDto, existedIdSetting);
        await _applicationSettingsRepository.UpdateAsync(existedIdSetting);
            
        result.Data = _mapper.Map<ApplicationSettingResponseDto>(existedIdSetting);
        return result;
    }

    public async Task<BaseResponse<ApplicationSettingResponseDto>> GetSettingAsync(int settingId)
    {
        var result = new BaseResponse<ApplicationSettingResponseDto>(null);

        // Получить существующую настройку
        var existedIdSetting = await _applicationSettingsRepository.GetByIdAsync(settingId);

        if (existedIdSetting == null)
        {
            result.Description = $"Настройки с Id = [{settingId}] не найдены";
            return result;
        }

        result.Data = _mapper.Map<ApplicationSettingResponseDto>(existedIdSetting);
        return result;
    }

    public async Task<BaseResponse<BasePaginationResponse<ApplicationSettingResponseDto>>> GetPagedSettingsAsync(BasePagination pagination)
    {
        var result = new BaseResponse<BasePaginationResponse<ApplicationSettingResponseDto>>();

        var a = await _applicationSettingsRepository.GetAllSettingsAsync();
        var data = _mapper.Map<List<ApplicationSettingResponseDto>>(a);
        var total = await _applicationSettingsRepository.CountAllAsync();
        result.Data = new BasePaginationResponse<ApplicationSettingResponseDto>(pagination, total, data);
        return result;
    }

    public async Task<BaseResponse<string>> DeleteSettingAsync(int settingId)
    {
        var result = new BaseResponse<string>(null);

        // Получить существующую настройку
        var existedIdSetting = await _applicationSettingsRepository.GetByIdAsync(settingId);

        if (existedIdSetting == null)
        {
            result.Description = $"Настройки с Id = [{settingId}] не найдены";
            return result;
        }

        await _applicationSettingsRepository.DeleteAsync(existedIdSetting);
            
        result.Data = "Настройка удалена";
        return result;
    }

    public async Task<int> GetInt(string settingName)
    {
        var setting = await _applicationSettingsRepository.GetByNameAsync(settingName);

        if (setting == null)
        {
            throw new Exception($"Отсутствует настройка приложение с именем [{settingName}]");
        }
            
        if (int.TryParse(setting.Value, out var res) == false)
        {
            throw new Exception($"Настрока [{setting.Name}] должна быть типа int!");
        }

        return res;
    }

    public async Task<string> GetString(string settingName)
    {
        var setting = await _applicationSettingsRepository.GetByNameAsync(settingName);
            
        if (setting == null)
        {
            throw new Exception($"Отсутствует настройка приложение с именем [{settingName}]");
        }

        return setting.Value;
    }
        
    public async Task<EmailSettings> GetEmailSendData()
    {
        var settings = await _applicationSettingsRepository.GetRangeAsync();

        var emailSendSettings = new EmailSettings()
        {
            Password = settings.FirstOrDefault(s => s.Name == EducationSystemSettings.EMAIL_PASSWORD)?.Value,
            EmailAddress = settings.FirstOrDefault(s => s.Name == EducationSystemSettings.EMAIL)?.Value,
            SmtpClient = settings.FirstOrDefault(s => s.Name == EducationSystemSettings.SMTP_CLIENT)?.Value
        };

        var port = settings.FirstOrDefault(s => s.Name == EducationSystemSettings.SMTP_CLIENT_PORT)?.Value;

        if (int.TryParse(port, out var res) == false)
        {
            return null;
        }
            
        emailSendSettings.Port = res;

        return emailSendSettings;
    }
}