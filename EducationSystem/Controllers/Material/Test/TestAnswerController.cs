using EducationSystem.Dto.Material.Test.Answer;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Test;

[Authorize]
[ApiController]
[Route("api/test-answer")]
public class TestAnswerController : ControllerBaseExtension
{
    private readonly ITestAnswerService _testAnswerService;

    public TestAnswerController(ITestAnswerService testAnswerService)
    {
        _testAnswerService = testAnswerService;
    }
    
    [HttpGet]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Получить ответ теста по его id",
        Description = "Получить ответ теста по его id",
        OperationId = "TestAnswer.Get.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int testId)
    {
        var response = await _testAnswerService.GetTestAnswerByIdAsync(testId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить ответ тестаы по фильтрам",
        Description = "Получить ответ тестаы по фильтрам",
        OperationId = "TestAnswer.Get.List",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _testAnswerService.GetTestAnswerByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать ответ теста",
        Description = "Создать ответ теста",
        OperationId = "TestAnswer.Create",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateTestAnswerDto request)
    {
        var response = await _testAnswerService.CreateTestAnswerAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Обновить ответ теста по его id",
        Description = "Обновить ответ теста по его id",
        OperationId = "TestAnswer.Update.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Update([FromRoute] int testId, [FromBody] UpdateTestAnswerDto request)
    {
        var response = await _testAnswerService.UpdateTestAnswerByIdAsync(testId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Удалить ответ теста по его id",
        Description = "Удалить ответ теста по его id",
        OperationId = "TestAnswer.Delete.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int testId)
    {
        var response = await _testAnswerService.DeleteTestAnswerByIdAsync(testId);

        return Response(response);
    }
}