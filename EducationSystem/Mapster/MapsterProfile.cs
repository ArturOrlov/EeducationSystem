﻿using EducationSystem.Dto;
using EducationSystem.Dto.Identity.Role;
using EducationSystem.Dto.Identity.User;
using EducationSystem.Dto.Identity.UserInfo;
using EducationSystem.Entities.DbModels.Identity;
using Mapster;

namespace EducationSystem.Mapster;

public class MapsterProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // User
        config.NewConfig<User, GetUserDto>();
        
        // UserInfo
        config.NewConfig<UserInfo, UpdateUserDto>();
        config.NewConfig<UserInfo, GetUserInfoDto>();
        config.NewConfig<CreateUserInfoDto, UpdateUserInfoDto>();

        // Role
        config.NewConfig<UserRole, GetUserDto>();
        config.NewConfig<Role, GetRoleDto>();
        config.NewConfig<Role, CreateRoleDto>();

        // Settings
        config.NewConfig<ApplicationSettings, ApplicationSettingDto>();
        config.NewConfig<ApplicationSettings, ApplicationSettingResponseDto>();
    }
}