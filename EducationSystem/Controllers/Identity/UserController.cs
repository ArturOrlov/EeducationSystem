﻿using EducationSystem.Dto.Identity.User;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Identity;

// [Authorize]
[ApiController]
[Route("api/user")]
public class UserController : ControllerBaseExtension
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{userId:int}")]
    [SwaggerOperation(
        Summary = "Получить пользователя по его id",
        Description = "Получить пользователя по его id",
        OperationId = "User.Get.ById",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        var response = await _userService.GetByIdAsync(userId);

        return Response(response);
    }

    [HttpGet]
    [Route("self")]
    [SwaggerOperation(
        Summary = "Получить свои данные",
        Description = "Получить свои данные",
        OperationId = "User.Get.BySelf",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> GetBySelf()
    {
        var response = await _userService.GetByIdAsync(int.Parse(HttpContext.GetUserData().Id));

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить пользователей по фильтрам",
        Description = "Получить пользователей по фильтрам",
        OperationId = "User.Get.List",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] UserFilter request)
    {
        var response = await _userService.GetByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать пользователя",
        Description = "Создать пользователя",
        OperationId = "User.Create",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateUserDto request)
    {
        var response = await _userService.CreateAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{userId:int}")]
    [SwaggerOperation(
        Summary = "Обновить пользователя по его id",
        Description = "Обновить пользователя по его id",
        OperationId = "User.Update.ById",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserDto request)
    {
        var response = await _userService.UpdateByIdAsync(userId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{userId:int}")]
    [SwaggerOperation(
        Summary = "Удалить пользователя по его id",
        Description = "Удалить пользователя по его id",
        OperationId = "User.Delete.ById",
        Tags = new[] { "User" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int userId)
    {
        var response = await _userService.DeleteByIdAsync(userId);

        return Response(response);
    }
}