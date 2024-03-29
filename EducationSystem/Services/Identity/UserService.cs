﻿using EducationSystem.Dto.Identity.User;
using EducationSystem.Dto.Identity.UserInfo;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Services.Identity;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IUserInfoRepository userInfoRepository,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userInfoRepository = userInfoRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<User>> GetByLoginAsync(string login, string password)
    {
        var response = new BaseResponse<User>();

        var user = await _userManager.FindByNameAsync(login);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "Неверный логин или пароль";
            return response;
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

        if (isPasswordCorrect == false)
        {
            response.IsError = true;
            response.Description = "Неверный логин или пароль";
            return response;
        }

        response.Data = user;
        return response;
    }

    public async Task<BaseResponse<GetUserDto>> GetByIdAsync(int userId)
    {
        var response = new BaseResponse<GetUserDto>();

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {userId} не найден";
            return response;
        }

        var mapUser = _mapper.Map<GetUserDto>(user);

        var userInfo = await _userInfoRepository.GetByUserId(userId);

        mapUser.UserInfo = _mapper.Map<GetUserInfoDto>(userInfo);

        response.Data = mapUser;
        return response;
    }

    public async Task<BaseResponse<User>> FindUser(string userName)
    {
        var response = new BaseResponse<User>();
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с именем - {userName} не найден";
            return response;
        }

        response.Data = user;
        return response;
    }

    public async Task<BaseResponse<List<GetUserDto>>> GetByPaginationAsync(UserFilter request)
    {
        var response = new BaseResponse<List<GetUserDto>>();

        var users = await _userRepository.GetByPaginationAsync(request);

        response.Data = users;
        return response;
    }

    public async Task<BaseResponse<GetUserDto>> CreateAsync(CreateUserDto request)
    {
        var response = new BaseResponse<GetUserDto>();

        var checkEmail = await _userManager.FindByEmailAsync(request.Email);

        if (checkEmail != null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с почтой - {request.Email} уже существует";
            return response;
        }

        var checkUserName = await _userManager.FindByEmailAsync(request.UserName);

        if (checkUserName != null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с именем профиля - {request.UserName} уже существует";
            return response;
        }

        if (request.Password != request.ConfirmPassword)
        {
            response.IsError = true;
            response.Description = $"Пользователь пароль и подтверждённый пароль не совпадают";
            return response;
        }

        var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());

        if (role == null)
        {
            response.IsError = true;
            response.Description = $"Роль с id - {request.RoleId} не найдена";
            return response;
        }

        var user = _mapper.Map<User>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            response.IsError = true;
            response.Description = $"Ошибка создания пользователя";
            return response;
        }

        await _userManager.AddToRoleAsync(user, role.Name);

        if (request.UserInfo != null)
        {
            var userInfo = await _userInfoRepository.GetByUserId(user.Id);

            if (userInfo == null)
            {
                userInfo = new UserInfo()
                {
                    UserId = user.Id,
                    FirstName = request.UserInfo.FirstName ?? string.Empty,
                    LastName = request.UserInfo.LastName ?? string.Empty,
                    Patronymic = request.UserInfo.Patronymic ?? string.Empty,
                    Birthday = request.UserInfo.Birthday ?? default
                };

                await _userInfoRepository.CreateAsync(userInfo);
            }
            else
            {
                if (userInfo.FirstName != request.UserInfo.FirstName)
                {
                    userInfo.FirstName = request.UserInfo.FirstName;
                }
                
                if (userInfo.LastName != request.UserInfo.LastName)
                {
                    userInfo.LastName = request.UserInfo.LastName;
                }
                
                if (userInfo.Patronymic != request.UserInfo.Patronymic)
                {
                    userInfo.Patronymic = request.UserInfo.Patronymic;
                }
                
                if (userInfo.Birthday != request.UserInfo.Birthday)
                {
                    userInfo.Birthday = request.UserInfo.Birthday;
                }
                
                await _userInfoRepository.UpdateAsync(userInfo);
            }
        }

        var mapUser = _mapper.Map<GetUserDto>(user);

        response.Data = mapUser;
        return response;
    }

    public async Task<BaseResponse<GetUserDto>> UpdateByIdAsync(int userId, UpdateUserDto request)
    {
        var response = new BaseResponse<GetUserDto>();

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {userId} не найден";
            return response;
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            var checkEmail = await _userManager.FindByEmailAsync(request.Email);

            if (checkEmail != null)
            {
                response.IsError = true;
                response.Description = $"Пользователь с почтой - {request.Email} уже существует";
                return response;
            }

            user.Email = request.Email;
        }

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            user.PhoneNumber = request.PhoneNumber;
        }

        user.UpdatedAt = DateTime.Now;
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            response.IsError = true;
            response.Description = result.Errors.ToString();
            return response;
        }

        if (request.UserInfo != null)
        {
            var userInfo = await _userInfoRepository.GetByUserId(userId);

            if (userInfo == null)
            {
                userInfo = new UserInfo()
                {
                    UserId = userId,
                    FirstName = request.UserInfo.FirstName ?? string.Empty,
                    LastName = request.UserInfo.LastName ?? string.Empty,
                    Patronymic = request.UserInfo.Patronymic ?? string.Empty,
                    Birthday = request.UserInfo.Birthday ?? default
                };

                await _userInfoRepository.CreateAsync(userInfo);
            }
            else
            {
                if (userInfo.FirstName != request.UserInfo.FirstName)
                {
                    userInfo.FirstName = request.UserInfo.FirstName;
                }
                
                if (userInfo.LastName != request.UserInfo.LastName)
                {
                    userInfo.LastName = request.UserInfo.LastName;
                }
                
                if (userInfo.Patronymic != request.UserInfo.Patronymic)
                {
                    userInfo.Patronymic = request.UserInfo.Patronymic;
                }
                
                if (userInfo.Birthday != request.UserInfo.Birthday)
                {
                    userInfo.Birthday = request.UserInfo.Birthday;
                }
                
                await _userInfoRepository.UpdateAsync(userInfo);
            }
        }

        var mapUser = _mapper.Map<GetUserDto>(user);

        response.Data = mapUser;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteByIdAsync(int userId)
    {
        var response = new BaseResponse<string>();

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {userId} не найден";
            return response;
        }

        await _userManager.DeleteAsync(user);

        response.Data = "Удалено";
        return response;
    }

    public async Task<bool> AuthorizeClaimsAsync(User user, string claim)
    {
        // IList<Claim> listClaims;
        //
        // var userRole = await _roleRepository.GetRoleByUser(user);
        //
        // if (userRole != null)
        // {
        //     var identityRole = _mapper.Map<IdentityRole<int>>(userRole);
        //     listClaims = await _roleManager.GetClaimsAsync(identityRole);
        // }
        // else
        // {
        //     listClaims = await _userManager.GetClaimsAsync(user);
        // }
        //
        // if (listClaims.All(c => c.Type != claim))
        // {
        //     listClaims = await _userManager.GetClaimsAsync(user);
        // }
        //
        // return listClaims.Any(c => c.Type == claim);

        return true;
    }

    // // todo подумать над тем что бы сделать модели create и update более абстрактными и объединить их
    // private async Task<bool> ValidateUserInfo(CreateUserInfoDto userInfo)
    // {
    //     if (userInfo.ChildrenUserId != null && userInfo.IsParent && userInfo.ChildrenUserId.Any())
    //     {
    //         var student = await _userManager.FindByIdAsync(userInfo.ChildrenUserId);
    //
    //         if (student == null)
    //         {
    //             return false;
    //         }
    //     }
    //
    //     return true;
    // }
    //
    // private async Task<bool> ValidateUserInfo(UpdateUserInfoDto userInfo)
    // {
    //     if (userInfo.ChildrenUserId != null && userInfo.IsParent && userInfo.ChildrenUserId.Any())
    //     {
    //         var student = await _userManager.FindByIdAsync(userInfo.ChildrenUserId);
    //
    //         if (student == null)
    //         {
    //             return false;
    //         }
    //     }
    //
    //     return true;
    // }
}