﻿using System.Security.Claims;
using EducationSystem.Dto.Identity.User;

namespace EducationSystem.Extension;

public static class HttpContentExtension
{
    public static UserDataDto GetUserData(this HttpContext context)
    {
        return new UserDataDto
        {
            Id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            Name = context.User.FindFirst(ClaimTypes.Name)?.Value,
            Role = context.User.FindFirst(ClaimTypes.Role)?.Value,
        };
    }
    
    public static string GetUserAgent(this HttpContext context)
    {
        return context.Request.Headers["User-Agent"];
    }
}