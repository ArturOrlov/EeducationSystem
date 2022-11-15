using EducationSystem.Dto;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.ApplicationSettings;

[Authorize]
[ApiController]
[Route("api/dictionary/setting")]
public class SettingController : ControllerBaseExtension
{
    private readonly IDictionarySettingService _dictionarySettingService;

    public SettingController(IDictionarySettingService dictionarySettingService)
    {
        _dictionarySettingService = dictionarySettingService;
    }

    [HttpGet]
    [Route("{settingId}")]
    [SwaggerOperation(
        Summary = "Получение настройки приложения",
        Description = "Получение настройки приложения",
        OperationId = "Dictionary.Settings.Get",
        Tags = new[] { "Dictionary.Settings" }
    )]
    public async Task<ActionResult<string>> GetSettings([FromRoute] int settingId)
    {
        var response = await _dictionarySettingService.GetSettingAsync(settingId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получение настроек приложения с пагинацией",
        Description = "Получение настроек приложения с пагинацией",
        OperationId = "Dictionary.Settings.GetPaged",
        Tags = new[] { "Dictionary.Settings" }
    )]
    public async Task<ActionResult<string>> GetAllSettings([FromQuery] BasePagination pagination,
        CancellationToken cancellationToken = new())
    {
        var response = await _dictionarySettingService.GetPagedSettingsAsync(pagination);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Добавление настройки приложения",
        Description = "Добавление настройки приложения",
        OperationId = "Dictionary.Settings.Add",
        Tags = new[] { "Dictionary.Settings" }
    )]
    public async Task<ActionResult<string>> CreateSettings([FromBody] ApplicationSettingDto request)
    {
        var response = await _dictionarySettingService.AddSettingAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{settingId}")]
    [SwaggerOperation(
        Summary = "Обновление настройки приложения",
        Description = "Обновление настройки приложения",
        OperationId = "Dictionary.Settings.Update",
        Tags = new[] { "Dictionary.Settings" }
    )]
    public async Task<ActionResult<string>> UpdateSettings([FromRoute] int settingId, [FromBody] ApplicationSettingDto requestData)
    {
        var response = await _dictionarySettingService.UpdateSettingAsync(settingId, requestData);

        return Response(response);
    }

    [HttpDelete]
    [Route("{settingId}")]
    [SwaggerOperation(
        Summary = "Удаление настройки приложения",
        Description = "Удаление настройки приложения",
        OperationId = "Dictionary.Settings.Delete",
        Tags = new[] { "Dictionary.Settings" }
    )]
    public async Task<ActionResult<string>> DeleteSettings(int settingId)
    {
        var response = await _dictionarySettingService.DeleteSettingAsync(settingId);

        return Response(response);
    }
}