using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Repositories;
using EducationSystem.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Caching.Memory;

namespace EducationSystem.Extension;

public static class ServiceProviderExtensions
{
    /// <summary>
    /// Зарегестрировать сервисы
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<Bootstrap.Bootstrap>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();
        
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserRoleService, UserRoleService>();
        services.AddTransient<IUserInfoService, UserInfoService>();
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<ISettingService, SettingService>();
        services.AddTransient<IDictionarySettingService, SettingService>();
        services.AddTransient<IVerificationTokenService, VerificationTokenService>();
        services.AddTransient<IClaimService, ClaimService>();
        services.AddTransient<IUserClaimService, UserClaimService>();
        services.AddTransient<IRoleClaimService, RoleClaimService>();

        // services.AddTransient<ISubjectService, SubjectService>();
        // services.AddTransient<IPerformanceRatingService, PerformanceRatingService>();
    }
    
    /// <summary>
    /// Зарегестрировать репозитории
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddCustomRepository(this IServiceCollection services)
    {
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserRoleRepository, UserRoleRepository>();
        services.AddTransient<IUserInfoRepository, UserInfoRepository>();
        
        services.AddTransient<IApplicationSettingsRepository, ApplicationSettingsRepository>();
        services.AddTransient<IVerificationTokenRepository, VerificationTokenRepository>();
        services.AddTransient<IDeviceRepository, DeviceRepository>();
        services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddTransient<IUserClaimRepository, UserClaimRepository>();
        services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
        
        // services.AddTransient<ISubjectRepository, SubjectRepository>();
        // services.AddTransient<IPerformanceRatingRepository, PerformanceRatingRepository>();
    }
}