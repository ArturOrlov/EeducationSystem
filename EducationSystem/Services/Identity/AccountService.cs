using System.Text.Json;
using EducationSystem.Dto;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Extension;
using EducationSystem.Helpers;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Services.Identity;

public class AccountService : IAccountService
{
    private const int CODE_LENGTH = 6;

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IDeviceRepository _deviceRepository;
    private readonly IVerificationTokenRepository _verificationTokenRepository;
    private readonly IVerificationTokenService _verificationTokenService;
    private readonly IEmailService _emailService;

    public AccountService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        IDeviceRepository deviceRepository,
        IVerificationTokenRepository verificationTokenRepository,
        IVerificationTokenService verificationTokenService,
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _deviceRepository = deviceRepository;
        _verificationTokenRepository = verificationTokenRepository;
        _verificationTokenService = verificationTokenService;
        _emailService = emailService;
    }

    public async Task<BaseResponse<User>> LoginAsync(AuthRequest requestDto)
    {
        var response = new BaseResponse<User>();

        string login = null;

        if (ParserHelper.TryParsePhoneNumber(requestDto.Login, out string phoneNumber))
        {
            login = phoneNumber;
        }

        if (ParserHelper.TryParseEmail(requestDto.Login, out string email))
        {
            login = email;
        }

        if (login == null)
        {
            response.IsError = true;
            response.Description = "Invalid password or login";
            return response;
        }

        var user = await _signInManager.UserManager.FindByNameAsync(login);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "Invalid password or login";
            return response;
        }

        var result = await _signInManager.PasswordSignInAsync(login, requestDto.Password, false, false);
        if (result.IsLockedOut)
        {
            response.IsError = true;
            response.Description = "Account denied";
            return response;
        }

        if (result.IsNotAllowed)
        {
            response.IsError = true;
            response.Description = "Is not allowed";
            return response;
        }

        if (result.RequiresTwoFactor)
        {
            response.IsError = true;
            response.Description = "Two factor auth";
            return response;
        }

        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user);

            response.Data = user;
            return response;
        }

        response.IsError = true;
        response.Description = "Invalid password or login";
        return response;
    }

    public async Task<Device> SetDeviceActivityAsync(int userId, HttpContext httpContext)
    {
        var userDevice = _deviceRepository.GetByUserId(userId);

        if (userDevice == null)
        {
            var device = new Device
            {
                UserAgent = httpContext.GetUserAgent(),
                LastLoginTime = DateTime.Now,
                UserId = userId
            };

            await _deviceRepository.CreateAsync(device);
            return device;
        }

        // Изменить информацию об устройсте
        userDevice.LastLoginTime = DateTime.Now;
        userDevice.UserAgent = httpContext.GetUserAgent();
        await _deviceRepository.UpdateAsync(userDevice);
        return userDevice;
    }

    public async Task<BaseResponse<object>> SendPasswordRestoreMessageViaLink(string restorePasswordPageUrl, string userEmail)
    {
        var response = new BaseResponse<object>();

        if (string.IsNullOrEmpty(restorePasswordPageUrl))
        {
            response.IsError = true;
            response.Description = "Need confirmation link";
            return response;
        }

        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "Email not found";
            return response;
        }

        // Сгенерировать Hash код
        var generatedToken = _verificationTokenService.GenerateToken();
        await _verificationTokenService.SaveDataAndCreateTokenAsync(generatedToken, user);

        // Отправить ссылку на восстановление
        restorePasswordPageUrl = restorePasswordPageUrl.Trim('/', ' ');
        var restoreLink = $"{restorePasswordPageUrl}?token={generatedToken}";

        var sendingResult = await _emailService.SendMessageAsync(user.Email,
            "Восстановление пароля",
            $"Для восстановления пароля перейдите по ссылке => {restoreLink}");

        if (!sendingResult)
        {
            response.IsError = true;
            response.Description = "Internal email sending error";
            return response;
        }

        // Сохранить хэш код
        var tokenData = JsonSerializer.Serialize(user);
        var newToken = new VerificationToken(generatedToken, tokenData);
        await _verificationTokenRepository.CreateAsync(newToken);

        response.Data = "Ссылка на восстановление пароля отправлена";
        return response;
    }

    public async Task<BaseResponse<object>> SendPasswordRestoreMessageViaVerificationCode(string login)
    {
        var response = new BaseResponse<object>();

        var user = await _userManager.FindByNameAsync(login) ?? await _userManager.FindByEmailAsync(login);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "User not found";
            return response;
        }

        // Сгенерировать Hash код
        var generatedToken = _verificationTokenService.GenerateToken(CODE_LENGTH);
        await _verificationTokenService.SaveDataAndCreateTokenAsync(generatedToken, user);

        // Отправить код на восстановление
        if (user.Email != null)
        {
            var sendingResult = await _emailService.SendMessageAsync(user.Email,
                "Восстановление пароля",
                $"Ваш код для восстановления => {generatedToken}");

            if (!sendingResult)
            {
                response.IsError = true;
                response.Description = "Internal email sending error";
                return response;
            }
        }
        else
        {
            throw new Exception("User has no email and phone");
        }

        //Сохранить хэш код
        var tokenData = JsonSerializer.Serialize(user);
        var newToken = new VerificationToken(generatedToken, tokenData);
        await _verificationTokenRepository.CreateAsync(newToken);

        response.Data = "Ссылка на восстановление пароля отправлена";
        return response;
    }

    public async Task<BaseResponse<object>> ChangePassword(ChangePasswordRequest request)
    {
        var response = new BaseResponse<object>()
        {
            Data = null
        };

        if (request.Password != request.PasswordConfirm)
        {
            response.IsError = true;
            response.Description = "Passwords are not equals";
            return response;
        }

        if (_verificationTokenService.TryGetData(request.Token, out User tokenData) == false)
        {
            response.IsError = true;
            response.Description = "Invalid confirmation token";
            return response;
        }

        var user = await _userManager.FindByIdAsync(tokenData.Id.ToString());
        var validators = _userManager.PasswordValidators;

        // Проверка валидации пароля
        foreach (var validator in validators)
        {
            var validatorResult = await validator.ValidateAsync(_userManager, user, request.Password);

            // Не прошел валидацию
            if (validatorResult.Succeeded == false)
            {
                response.IsError = true;
                response.Description = "Invalid password format";
                return response;
            }
        }

        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, request.Password);
        await _verificationTokenService.DeleteTokenAsync(request.Token);

        response.Data = "Пароль изменен";
        return response;
    }

    public async Task<IActionResult> LogoutAsync()
    {
        await _signInManager.SignOutAsync();

        return new OkResult();
    }
}