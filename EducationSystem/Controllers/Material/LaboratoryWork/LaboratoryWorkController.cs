using EducationSystem.Dto.Material.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.LaboratoryWork;

[Authorize]
[ApiController]
[Route("api/laboratory-work")]
public class LaboratoryWorkController : ControllerBaseExtension
{
    private readonly ILaboratoryWorkService _laboratoryWorkService;

    public LaboratoryWorkController(ILaboratoryWorkService laboratoryWorkService)
    {
        _laboratoryWorkService = laboratoryWorkService;
    }

    [HttpGet]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Получить лабораторную работу по его id",
        Description = "Получить лабораторную работу по его id",
        OperationId = "LaboratoryWork.Get.ById",
        Tags = new[] { "LaboratoryWork" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int laboratoryWorkId)
    {
        var response = await _laboratoryWorkService.GetLaboratoryWorkByIdAsync(laboratoryWorkId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить лабораторные работы по фильтрам",
        Description = "Получить лабораторные работы по фильтрам",
        OperationId = "LaboratoryWork.Get.List",
        Tags = new[] { "LaboratoryWork" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _laboratoryWorkService.GetLaboratoryWorkByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать лабораторную работу",
        Description = "Создать лабораторную работу",
        OperationId = "LaboratoryWork.Create",
        Tags = new[] { "LaboratoryWork" }
    )]
    public async Task<IActionResult> Create([FromForm] CreateLaboratoryWorkDto request)
    {
        var response = await _laboratoryWorkService.CreateLaboratoryWorkAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Обновить лабораторную работу по его id",
        Description = "Обновить лабораторную работу по его id",
        OperationId = "LaboratoryWork.Update.ById",
        Tags = new[] { "LaboratoryWork" }
    )]
    public async Task<IActionResult> Update([FromRoute] int laboratoryWorkId, [FromBody] UpdateLaboratoryWorkDto request)
    {
        var response = await _laboratoryWorkService.UpdateLaboratoryWorkByIdAsync(laboratoryWorkId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{laboratoryWorkId:int}")]
    [SwaggerOperation(
        Summary = "Удалить лабораторную работу по его id",
        Description = "Удалить лабораторную работу по его id",
        OperationId = "LaboratoryWork.Delete.ById",
        Tags = new[] { "LaboratoryWork" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int laboratoryWorkId)
    {
        var response = await _laboratoryWorkService.DeleteLaboratoryWorkByIdAsync(laboratoryWorkId);

        return Response(response);
    }
}