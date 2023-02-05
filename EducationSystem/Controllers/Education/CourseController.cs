using EducationSystem.Dto.Course;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Education;

[Authorize]
[ApiController]
[Route("api/course")]
public class CourseController : ControllerBaseExtension
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    [Route("{courseId:int}")]
    [SwaggerOperation(
        Summary = "Получить курс по его id",
        Description = "Получить курс по его id",
        OperationId = "Course.Get.ById",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int courseId)
    {
        var response = await _courseService.GetCourseByIdAsync(courseId);

        return Response(response);
    }

    [HttpGet]
    [Route("{courseId:int}/materials")]
    [SwaggerOperation(
        Summary = "Получить курс с материалами",
        Description = "Получить курс с материалами",
        OperationId = "Course.Get.WithMaterials",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> GetWithMaterials([FromRoute] int courseId)
    {
        var response = await _courseService.GetCourseWithMaterialsAsync(courseId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить курсы по фильтрам",
        Description = "Получить курсы по фильтрам",
        OperationId = "Course.Get.List",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _courseService.GetCourseByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать курс",
        Description = "Создать курс",
        OperationId = "Course.Create",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateCourseDto request)
    {
        var response = await _courseService.CreateCourseAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{courseId:int}")]
    [SwaggerOperation(
        Summary = "Обновить курс по его id",
        Description = "Обновить курс по его id",
        OperationId = "Course.Update.ById",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> Update([FromRoute] int courseId, [FromBody] UpdateCourseDto request)
    {
        var response = await _courseService.UpdateCourseByIdAsync(courseId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{courseId:int}")]
    [SwaggerOperation(
        Summary = "Удалить курс по его id",
        Description = "Удалить курс по его id",
        OperationId = "Course.Delete.ById",
        Tags = new[] { "Education.Course" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int courseId)
    {
        var response = await _courseService.DeleteCourseByIdAsync(courseId);

        return Response(response);
    }
}