using EducationSystem.Constants;
using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Dictionaries;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
using Role = EducationSystem.Entities.DbModels.Identity.Role;

namespace EducationSystem.Bootstrap;

public class Bootstrap
{
    private readonly EducationSystemDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IApplicationSettingsRepository _applicationSettingsRepository;

    public Bootstrap(EducationSystemDbContext context,
        UserManager<User> userManager,
        IApplicationSettingsRepository applicationSettingsRepository)
    {
        _context = context;
        _userManager = userManager;
        _applicationSettingsRepository = applicationSettingsRepository;
    }

    public async Task SeedDb()
    {
        await SeedRolesAsync();
        await SeedAdminAsync();
        await SeedSettings();

        // await SeedSchoolClassAsync();
        // await SeedSubjectAsync();
    }

    private async Task SeedRolesAsync()
    {
        if (_context.Role.Any())
        {
            return;
        }

        var roles = new List<Role>()
        {
            RoleSeedHelper(Constants.Role.Admin),
            RoleSeedHelper(Constants.Role.HeadTeacher),
            RoleSeedHelper(Constants.Role.Teacher),
            RoleSeedHelper(Constants.Role.Student)
        };

        await _context.AddRangeAsync(roles);
        await _context.SaveChangesAsync();
    }

    private async Task SeedAdminAsync()
    {
        if (_context.Users.Any(u => u.UserName == AdminDefaultSettings.UserName))
        {
            return;
        }

        var user = new User()
        {
            Email = AdminDefaultSettings.Email,
            NormalizedEmail = AdminDefaultSettings.Email.ToUpper(),
            UserName = AdminDefaultSettings.UserName,
            NormalizedUserName = AdminDefaultSettings.UserName.ToUpper(),
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            UpdatedAt = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, AdminDefaultSettings.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, Constants.Role.Admin);
        }
    }

    private async Task SeedSettings()
    {
        var settings = new List<ApplicationSettings>()
        {
            new(EducationSystemSettings.SMTP_CLIENT, "Адрес SMTP клиента", "smtp.gmail.com"),
            new(EducationSystemSettings.SMTP_CLIENT_PORT, "Порт SMTP клиента", "587"),
            new(EducationSystemSettings.EMAIL, "Электронная почта приложения", "educationSystem.sender@gmail.com"),
            new(EducationSystemSettings.EMAIL_PASSWORD, "Пароль электронной почты", "123"),
            new(EducationSystemSettings.JWT_TOKEN_HOURS, "Длительность действия JWT токена (часов)", "24"),
            new(EducationSystemSettings.JWT_REFRESH_HOURS, "Длительность действия REFRESH токена (часов)", "168"),
            new(EducationSystemSettings.VERIFICATION_TOKEN_LIFE, "Длительность кодов подтверждения (часов)", "3"),
            new(EducationSystemSettings.WEBSITE_ADDRESS, "Адрес внешнего сайта", "192.168.0.2"),
            new(EducationSystemSettings.WEBSITE_LOGIN, "Логин для подключения к серверу внешнего сайта", "username"),
            new(EducationSystemSettings.WEBSITE_PASSWORD, "Пароль для подключения к серверу внешнего сайта", "mypass"),
            new(EducationSystemSettings.WEBSITE_FTP_PORT, "Порт для FTP подключения к серверу внешнего сайта", "21"),
            new(EducationSystemSettings.WEBSITE_SERVER_EXPORT_STATISTICS_ENABLE, "Включить/выключить FTP отправку статистики", "false"),
        };

        foreach (var setting in settings)
        {
            if (await _applicationSettingsRepository.GetByNameAsync(setting.Name) == null)
            {
                await _applicationSettingsRepository.CreateAsync(setting);
            }
        }
    }

    // private async Task SeedSchoolClassAsync()
    // {
    //     if (_context.SchoolClass.Any())
    //     {
    //         return;
    //     }
    //
    //     var schoolClasses = new List<SchoolClass>()
    //     {
    //         new() { ClassCreateTime = ClassDateSeedHelper(2022), Symbol = "А" }, // 1 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2021), Symbol = "Б" }, // 2 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2020), Symbol = "В" }, // 3 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2019), Symbol = "Г" }, // 4 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2018), Symbol = "Д" }, // 5 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2017), Symbol = "А" }, // 6 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2016), Symbol = "Б" }, // 7 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2015), Symbol = "В" }, // 8 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2014), Symbol = "Г" }, // 9 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2013), Symbol = "Д" }, // 10 год/класс
    //         new() { ClassCreateTime = ClassDateSeedHelper(2012), Symbol = "А" }, // 11 год/класс
    //     };
    //
    //     await _context.AddRangeAsync(schoolClasses);
    //     await _context.SaveChangesAsync();
    // }
    //
    // private async Task SeedSubjectAsync()
    // {
    //     if (_context.Subject.Any())
    //     {
    //         return;
    //     }
    //
    //     var subjects = new List<Subject>()
    //     {
    //         new() { Name = "Русский язык" },
    //         new() { Name = "Литература" },
    //         new() { Name = "Математика" },
    //         new() { Name = "Геометрия" },
    //         new() { Name = "Алгебра" },
    //         new() { Name = "География" },
    //         new() { Name = "Информатика" },
    //         new() { Name = "Биология" },
    //         new() { Name = "Физика" },
    //         new() { Name = "Химия" },
    //         new() { Name = "Английский язык" },
    //         new() { Name = "Физкультура" },
    //         new() { Name = "Рисование" },
    //         new() { Name = "Черчение" },
    //         new() { Name = "Труд" },
    //         new() { Name = "ОБЖ" },
    //     };
    //
    //     await _context.AddRangeAsync(subjects);
    //     await _context.SaveChangesAsync();
    // }

    // ============================================================================================================== //

    private Role RoleSeedHelper(string role)
    {
        return new Role()
        {
            Name = role,
            NormalizedName = role.ToUpper(),
            ConcurrencyStamp = Convert.ToString(DateTime.Now.Ticks),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}