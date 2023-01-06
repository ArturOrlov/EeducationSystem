using EducationSystem.Dto.Material.Test.Question;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Test;

[Authorize]
[ApiController]
[Route("api/test-question")]
public class TestQuestionController : ControllerBaseExtension
{
    private readonly ITestQuestionService _testQuestionService;

    public TestQuestionController(ITestQuestionService testQuestionService)
    {
        _testQuestionService = testQuestionService;
    }
    
    [HttpGet]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Получить вопрос теста по его id",
        Description = "Получить вопрос теста по его id",
        OperationId = "TestQuestion.Get.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int testId)
    {
        var response = await _testQuestionService.GetTestQuestionByIdAsync(testId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить вопрос тестаы по фильтрам",
        Description = "Получить вопрос тестаы по фильтрам",
        OperationId = "TestQuestion.Get.List",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _testQuestionService.GetTestQuestionByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать вопрос теста",
        Description = "Создать вопрос теста",
        OperationId = "TestQuestion.Create",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Create([FromForm] CreateTestQuestionDto request)
    {
        var response = await _testQuestionService.CreateTestQuestionAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Обновить вопрос теста по его id",
        Description = "Обновить вопрос теста по его id",
        OperationId = "TestQuestion.Update.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Update([FromRoute] int testId, [FromBody] UpdateTestQuestionDto request)
    {
        var response = await _testQuestionService.UpdateTestQuestionByIdAsync(testId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Удалить вопрос теста по его id",
        Description = "Удалить вопрос теста по его id",
        OperationId = "TestQuestion.Delete.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int testId)
    {
        var response = await _testQuestionService.DeleteTestQuestionByIdAsync(testId);

        return Response(response);
    }
}