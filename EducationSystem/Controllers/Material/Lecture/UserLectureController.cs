using EducationSystem.Dto.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.Lecture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Lecture;

[Authorize]
[ApiController]
[Route("api/user-lecture")]
public class UserLectureController : ControllerBaseExtension
{
    private readonly IUserLectureService _lectureService;

    public UserLectureController(IUserLectureService lectureService)
    {
        _lectureService = lectureService;
    }

    [HttpGet]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Получить запись пользователь-лекция по его id",
        Description = "Получить запись пользователь-лекция по его id",
        OperationId = "UserLecture.Get.ById",
        Tags = new[] { "UserLecture" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int lectureId)
    {
        var response = await _lectureService.GetUserLectureByIdAsync(lectureId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить записи пользователь-лекция по фильтрам",
        Description = "Получить записи пользователь-лекция по фильтрам",
        OperationId = "UserLecture.Get.List",
        Tags = new[] { "UserLecture" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _lectureService.GetUserLectureByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать запись пользователь-лекция",
        Description = "Создать запись пользователь-лекция",
        OperationId = "UserLecture.Create",
        Tags = new[] { "UserLecture" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateUserLectureDto request)
    {
        var response = await _lectureService.CreateUserLectureAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Обновить запись пользователь-лекция по его id",
        Description = "Обновить запись пользователь-лекция по его id",
        OperationId = "UserLecture.Update.ById",
        Tags = new[] { "UserLecture" }
    )]
    public async Task<IActionResult> Update([FromRoute] int lectureId, [FromBody] UpdateUserLectureDto request)
    {
        var response = await _lectureService.UpdateUserLectureByIdAsync(lectureId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{lectureId:int}")]
    [SwaggerOperation(
        Summary = "Удалить запись пользователь-лекция по его id",
        Description = "Удалить запись пользователь-лекция по его id",
        OperationId = "UserLecture.Delete.ById",
        Tags = new[] { "UserLecture" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int lectureId)
    {
        var response = await _lectureService.DeleteUserLectureByIdAsync(lectureId);

        return Response(response);
    }
}