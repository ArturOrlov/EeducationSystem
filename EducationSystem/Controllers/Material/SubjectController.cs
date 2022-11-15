using EducationSystem.Dto.Subject;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material;

[Authorize]
[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBaseExtension
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    [Route("{subjectId:int}")]
    [SwaggerOperation(
        Summary = "Получить предмет по его id",
        Description = "Получить предмет по его id",
        OperationId = "Subject.Get.ById",
        Tags = new[] { "Subject" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int subjectId)
    {
        var response = await _subjectService.GetSubjectByIdAsync(subjectId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить предметы по фильтрам",
        Description = "Получить предметы по фильтрам",
        OperationId = "Subject.Get.List",
        Tags = new[] { "Subject" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _subjectService.GetSubjectByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать предмет",
        Description = "Создать предмет",
        OperationId = "Subject.Create",
        Tags = new[] { "Subject" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateSubjectDto request)
    {
        var response = await _subjectService.CreateSubjectAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{subjectId:int}")]
    [SwaggerOperation(
        Summary = "Обновить предмет по его id",
        Description = "Обновить предмет по его id",
        OperationId = "Subject.Update.ById",
        Tags = new[] { "Subject" }
    )]
    public async Task<IActionResult> Update([FromRoute] int subjectId, [FromBody] UpdateSubjectDto request)
    {
        var response = await _subjectService.UpdateSubjectByIdAsync(subjectId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{subjectId:int}")]
    [SwaggerOperation(
        Summary = "Удалить предмет по его id",
        Description = "Удалить предмет по его id",
        OperationId = "Subject.Delete.ById",
        Tags = new[] { "Subject" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int subjectId)
    {
        var response = await _subjectService.DeleteSubjectByIdAsync(subjectId);

        return Response(response);
    }
}