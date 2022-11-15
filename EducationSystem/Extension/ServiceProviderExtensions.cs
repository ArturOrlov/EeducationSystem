using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;
using EducationSystem.Interfaces.IRepositories.Material.Test;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Identity;
using EducationSystem.Interfaces.IServices.Material.Lecture;
using EducationSystem.Repositories;
using EducationSystem.Repositories.Identity;
using EducationSystem.Repositories.Material.Lecture;
using EducationSystem.Repositories.Material.Test;
using EducationSystem.Services;
using EducationSystem.Services.Identity;
using EducationSystem.Services.Material.Lecture;
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
        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<ISubjectService, SubjectService>();
        services.AddTransient<ILectureService, LectureService>();
        services.AddTransient<IUserLectureService, IUserLectureService>();
        // services.AddTransient<ITestHeadService, TestHeadService>();
        // services.AddTransient<ITestQuestionService, TestQuestionService>();
        // services.AddTransient<ITestAnswerService, TestAnswerService>();
        // services.AddTransient<IUserTestQuestionService, UserTestQuestionService>();
        // services.AddTransient<IUserTestQuestionService, UserTestQuestionService>();
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
        services.AddTransient<ILectureRepository, LectureRepository>();
        services.AddTransient<IUserLectureRepository, UserLectureRepository>();
        services.AddTransient<ITestHeadRepository, TestHeadRepository>();
        services.AddTransient<ITestQuestionRepository, TestQuestionRepository>();
        services.AddTransient<ITestAnswerRepository, TestAnswerRepository>();
        services.AddTransient<IUserTestQuestionRepository, UserTestQuestionRepository>();
        services.AddTransient<IUserTestQuestionRepository, UserTestQuestionRepository>();
        services.AddTransient<ISubjectRepository, SubjectRepository>();
        services.AddTransient<ICourseRepository, CourseRepository>();
    }
}