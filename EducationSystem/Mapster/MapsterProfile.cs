using EducationSystem.Dto;
using EducationSystem.Dto.Role;
using EducationSystem.Dto.User;
using EducationSystem.Dto.UserInfo;
using EducationSystem.Entities.DbModels.Dictionaries;
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