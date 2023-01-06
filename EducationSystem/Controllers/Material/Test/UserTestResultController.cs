using EducationSystem.Dto.Material.Test.UserResult;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Material.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Material.Test;

[Authorize]
[ApiController]
[Route("api/user-test-result")]
public class UserTestResultController : ControllerBaseExtension
{
    private readonly IUserTestResultService _userTestResultService;

    public UserTestResultController(IUserTestResultService userTestResultService)
    {
        _userTestResultService = userTestResultService;
    }
    
    [HttpGet]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Получить пользователь-результат теста по его id",
        Description = "Получить пользователь-результат теста по его id",
        OperationId = "UserTestResult.Get.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int testId)
    {
        var response = await _userTestResultService.GetUserTestResultByIdAsync(testId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить пользователь-результат тестаы по фильтрам",
        Description = "Получить пользователь-результат тестаы по фильтрам",
        OperationId = "UserTestResult.Get.List",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _userTestResultService.GetUserTestResultByPaginationAsync(request);

        return Response(response);
    }
    
    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать пользователь-результат теста",
        Description = "Принимаются данные результата ответа теста. на их основе считается результат",
        OperationId = "UserTestResult.Create",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateUserTestResultDto request)
    {
        var response = await _userTestResultService.CreateUserTestResultAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Обновить пользователь-результат теста по его id",
        Description = "Обновить пользователь-результат теста по его id",
        OperationId = "UserTestResult.Update.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Update([FromRoute] int testId, [FromBody] UpdateUserTestResultDto request)
    {
        var response = await _userTestResultService.UpdateUserTestResultByIdAsync(testId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{testId:int}")]
    [SwaggerOperation(
        Summary = "Удалить пользователь-результат теста по его id",
        Description = "Удалить пользователь-результат теста по его id",
        OperationId = "UserTestResult.Delete.ById",
        Tags = new[] { "Test" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int testId)
    {
        var response = await _userTestResultService.DeleteUserTestResultByIdAsync(testId);

        return Response(response);
    }
}