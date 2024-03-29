﻿using EducationSystem.Dto.Identity.UserInfo;

namespace EducationSystem.Dto.Identity.User;

public class CreateUserDto
{
    public int RoleId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public CreateUserInfoDto UserInfo { get; set; }
}