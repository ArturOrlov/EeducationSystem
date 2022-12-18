using EducationSystem.Dto.Test;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material;
using EducationSystem.Interfaces.IServices.Material.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Test;

[Authorize]
[ApiController]
[Route("api/test")]
public class TestController : ControllerBaseExtension
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Получить тест по его id",
        Description = "Получить тест по его id",
        OperationId = "Test.Get.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int testId)
    {
        var response = await _testService.GetTestByIdAsync(testId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить тесты по фильтрам",
        Description = "Получить тесты по фильтрам",
        OperationId = "Test.Get.List",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _testService.GetTestByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать тест",
        Description = "Создать тест",
        OperationId = "Test.Create",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateTestDto request)
    {
        var response = await _testService.CreateTestAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Обновить тест по его id",
        Description = "Обновить тест по его id",
        OperationId = "Test.Update.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Update([FromRoute] int testId, [FromBody] UpdateTestDto request)
    {
        var response = await _testService.UpdateTestByIdAsync(testId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Удалить тест по его id",
        Description = "Удалить тест по его id",
        OperationId = "Test.Delete.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int testId)
    {
        var response = await _testService.DeleteTestByIdAsync(testId);

        return Response(response);
    }
}