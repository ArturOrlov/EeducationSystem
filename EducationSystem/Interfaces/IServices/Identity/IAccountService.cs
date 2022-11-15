using EducationSystem.Dto;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Interfaces.IServices.Identity;

public interface IAccountService
{
    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="requestDto">Данные авторизации</param>
    /// <returns></returns>
    Task<BaseResponse<User>> LoginAsync(AuthRequest requestDto);

    /// <summary>
    /// Записать информацию об последней автивности пользователя в БД
    /// </summary>
    /// <param name="userId">идентификатор пользователя</param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    Task<Device> SetDeviceActivityAsync(int userId, HttpContext httpContext);

    /// <summary>
    /// Отправить Email на почту с сыллкой для восстановления пароля
    /// </summary>
    /// <param name="restorePageUrl"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<BaseResponse<object>> SendPasswordRestoreMessageViaLink(string restorePageUrl, string email);

    /// <summary>
    /// Отправить Email на почту с кодом для восстановления пароля
    /// </summary>
    /// <param name="userEmail"></param>
    /// <returns></returns>
    Task<BaseResponse<object>> SendPasswordRestoreMessageViaVerificationCode(string userEmail);
        
    /// <summary>
    /// Изменение пароля пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<object>> ChangePassword(ChangePasswordRequest request);
        
    /// <summary>
    /// Выход Пользователя
    /// </summary>
    /// <returns></returns>
    Task<IActionResult> LogoutAsync();
}