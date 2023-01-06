using EducationSystem.Dto.Report;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Report;

[Authorize]
[ApiController]
[Route("api/report")]
public class ReportController : ControllerBaseExtension
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    [HttpGet]
    [Route("user/performance/gpa")]
    [SwaggerOperation(
        Summary = "Получить отчёт средней оценки студента по курсу",
        Description = "Подсчитывает средний балл по завершённым тестам и лабораторным работам",
        OperationId = "Report.Get.User.Gpa",
        Tags = new[] { "Report" }
    )]
    public async Task<IActionResult> GetUserGpa([FromQuery] UserPerformanceReport request)
    {
        var response = await _reportService.GetUserGpa(request);

        return Response(response);
    }

    [HttpGet]
    [Route("user/performance")]
    [SwaggerOperation(
        Summary = "Получить отчёт по успеваемости студента по курсу",
        Description = "Выводит список продейных тестов и лабораторных работ с оценками",
        OperationId = "Report.Get.User.Performance",
        Tags = new[] { "Report" }
    )]
    public async Task<IActionResult> GetUserPerformance([FromQuery] UserPerformanceReport request)
    {
        var response = await _reportService.GetUserPerformance(request);

        return Response(response);
    }
}