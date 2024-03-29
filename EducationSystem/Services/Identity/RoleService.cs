﻿using EducationSystem.Dto.Identity.Role;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Services.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(RoleManager<Role> roleManager, 
        IRoleRepository roleRepository,
        IMapper mapper)
    {
        _roleManager = roleManager;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetRoleDto>> GetRoleByIdAsync(int roleId)
    {
        var response = new BaseResponse<GetRoleDto>();

        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            response.IsError = true;
            response.Description = $"Роль с id - {roleId} не найден";
            return response;
        }

        var mapRole = _mapper.Map<GetRoleDto>(role);

        response.Data = mapRole;
        return response;
    }

    public async Task<BaseResponse<List<GetRoleDto>>> GetRoleByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetRoleDto>>();

        var roles = _roleManager.Roles.Skip(request.Skip).Take(request.Take).ToList();

        if (!roles.Any())
        {
            return response;
        }

        var mapRoles = _mapper.Map<List<GetRoleDto>>(roles);

        response.Data = mapRoles;
        return response;
    }

    public async Task<BaseResponse<GetRoleDto>> CreateRoleAsync(CreateRoleDto request)
    {
        var response = new BaseResponse<GetRoleDto>();

        var checkName = await _roleManager.FindByNameAsync(request.Name);

        if (checkName != null)
        {
            response.IsError = true;
            response.Description = $"Роль с именем - {request.Name} уже есть";
            return response;
        }

        var role = _mapper.Map<Role>(request);

        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            response.IsError = true;
            response.Description = result.Errors.ToString();
            return response;
        }

        var mapRole = _mapper.Map<GetRoleDto>(result);

        response.Data = mapRole;
        return response;
    }

    public async Task<BaseResponse<GetRoleDto>> UpdateRoleByIdAsync(int roleId, UpdateRoleDto request)
    {
        var response = new BaseResponse<GetRoleDto>();

        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            response.IsError = true;
            response.Description = $"Роль с id - {roleId} не найдено";
            return response;
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var checkName = await _roleManager.FindByNameAsync(request.Name);

            if (checkName != null)
            {
                response.IsError = true;
                response.Description = $"Роль с именем - {request.Name} уже есть";
                return response;
            }

            role.Name = request.Name;
        }

        role.UpdatedAt = DateTime.Now;
        var result = await _roleManager.UpdateAsync(role);

        if (!result.Succeeded)
        {
            response.IsError = true;
            response.Description = result.Errors.ToString();
            return response;
        }

        var mapRole = _mapper.Map<GetRoleDto>(result);

        response.Data = mapRole;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteRoleByIdAsync(int roleId)
    {
        var response = new BaseResponse<string>();

        var homework = await _roleManager.FindByIdAsync(roleId.ToString());

        if (homework == null)
        {
            response.IsError = true;
            response.Description = $"Роль с id - {roleId} не найдено";
            return response;
        }

        await _roleManager.DeleteAsync(homework);

        response.Data = "Удалено";
        return response;
    }
}