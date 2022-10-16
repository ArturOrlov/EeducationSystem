using System.Security.Claims;
using EducationSystem.Dto.User;

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
}