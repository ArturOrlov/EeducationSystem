﻿using EducationSystem.Dto.Identity.Role;
using EducationSystem.Entities.Base;
using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Identity;

[Authorize]
[ApiController]
[Route("api/role")]
public class RoleController : ControllerBaseExtension
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("{roleId:int}")]
    [SwaggerOperation(
        Summary = "Получить роль по его id",
        Description = "Получить роль по его id",
        OperationId = "Role.Get.ById",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> GetById([FromRoute] int roleId)
    {
        var response = await _roleService.GetRoleByIdAsync(roleId);

        return Response(response);
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получить роли по фильтрам",
        Description = "Получить роли по фильтрам",
        OperationId = "Role.Get.List",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> GetAll([FromQuery] BasePagination request)
    {
        var response = await _roleService.GetRoleByPaginationAsync(request);

        return Response(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation(
        Summary = "Создать роль",
        Description = "Создать роль",
        OperationId = "Role.Create",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> Create([FromBody] CreateRoleDto request)
    {
        var response = await _roleService.CreateRoleAsync(request);

        return Response(response);
    }

    [HttpPut]
    [Route("{roleId:int}")]
    [SwaggerOperation(
        Summary = "Обновить роль по его id",
        Description = "Обновить роль по его id",
        OperationId = "Role.Update.ById",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> Update([FromRoute] int roleId, [FromBody] UpdateRoleDto request)
    {
        var response = await _roleService.UpdateRoleByIdAsync(roleId, request);

        return Response(response);
    }

    [HttpDelete]
    [Route("{roleId:int}")]
    [SwaggerOperation(
        Summary = "Удалить роль по его id",
        Description = "Удалить роль по его id",
        OperationId = "Role.Delete.ById",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> Delete([FromRoute] int roleId)
    {
        var response = await _roleService.DeleteRoleByIdAsync(roleId);

        return Response(response);
    }
}