using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.Lecture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Lecture;

[Authorize]
[ApiController]
[Route("api/lecture")]
public class LectureController : ControllerBaseExtension
{
    private readonly ILectureService _lectureService;

    public LectureController(ILectureService lectureService)
    {
        _lectureService = lectureService;
    }

    [HttpGet]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Получить лекцию по его id",
        Description = "Получить лекцию по его id",
        OperationId = "Lecture.Get.ById",
        Tags = new[] { "Lecture" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int lectureId)
    {
        var response = await _lectureService.GetLectureByIdAsync(lectureId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить лекции по фильтрам",
        Description = "Получить лекции по фильтрам",
        OperationId = "Lecture.Get.List",
        Tags = new[] { "Lecture" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _lectureService.GetLectureByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать лекцию",
        Description = "Создать лекцию",
        OperationId = "Lecture.Create",
        Tags = new[] { "Lecture" }
    )]
    public async Task<IActionResult> Create([FromForm] CreateLectureDto request)
    {
        var response = await _lectureService.CreateLectureAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Обновить лекцию по его id",
        Description = "Обновить лекцию по его id",
        OperationId = "Lecture.Update.ById",
        Tags = new[] { "Lecture" }
    )]
    public async Task<IActionResult> Update([FromRoute] int lectureId, [FromBody] UpdateLectureDto request)
    {
        var response = await _lectureService.UpdateLectureByIdAsync(lectureId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Удалить лекцию по его id",
        Description = "Удалить лекцию по его id",
        OperationId = "Lecture.Delete.ById",
        Tags = new[] { "Lecture" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int lectureId)
    {
        var response = await _lectureService.DeleteLectureByIdAsync(lectureId);

        return Response(response);
    }
}