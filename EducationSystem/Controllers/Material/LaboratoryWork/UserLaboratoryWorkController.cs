using EducationSystem.Dto.Materail.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.LaboratoryWork;

[Authorize]
[ApiController]
[Route("api/user-laboratory-work")]
public class UserLaboratoryWorkController : ControllerBaseExtension
{
    private readonly IUserLaboratoryWorkService _userLaboratoryWorkService;

    public UserLaboratoryWorkController(IUserLaboratoryWorkService lectureService)
    {
        _userLaboratoryWorkService = lectureService;
    }

    [HttpGet]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Получить запись пользователь-лабораторная работа по его id",
        Description = "Получить запись пользователь-лабораторная работа по его id",
        OperationId = "UserLaboratoryWork.Get.ById",
        Tags = new[] { "UserLaboratoryWork" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int laboratoryWorkId)
    {
        var response = await _userLaboratoryWorkService.GetUserLaboratoryWorkByIdAsync(laboratoryWorkId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить записи пользователь-лабораторная работа по фильтрам",
        Description = "Получить записи пользователь-лабораторная работа по фильтрам",
        OperationId = "UserLaboratoryWork.Get.List",
        Tags = new[] { "UserLaboratoryWork" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _userLaboratoryWorkService.GetUserLaboratoryWorkByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать запись пользователь-лабораторная работа",
        Description = "Создать запись пользователь-лабораторная работа",
        OperationId = "UserLaboratoryWork.Create",
        Tags = new[] { "UserLaboratoryWork" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateUserLaboratoryWorkDto request)
    {
        var response = await _userLaboratoryWorkService.CreateUserLaboratoryWorkAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Обновить запись пользователь-лабораторная работа по его id",
        Description = "Обновить запись пользователь-лабораторная работа по его id",
        OperationId = "UserLaboratoryWork.Update.ById",
        Tags = new[] { "UserLaboratoryWork" }
    )]
    public async Task<IActionResult> Update([FromRoute] int laboratoryWorkId, [FromBody] UpdateUserLaboratoryWorkDto request)
    {
        var response = await _userLaboratoryWorkService.UpdateUserLaboratoryWorkByIdAsync(laboratoryWorkId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Удалить запись пользователь-лабораторная работа по его id",
        Description = "Удалить запись пользователь-лабораторная работа по его id",
        OperationId = "UserLaboratoryWork.Delete.ById",
        Tags = new[] { "UserLaboratoryWork" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int laboratoryWorkId)
    {
        var response = await _userLaboratoryWorkService.DeleteUserLaboratoryWorkByIdAsync(laboratoryWorkId);

        return Response(response);
    }
}