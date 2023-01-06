using EducationSystem.Dto.Identity.UserInfo;

namespace EducationSystem.Dto.Identity.User;

public class UpdateUserDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public UpdateUserInfoDto UserInfo { get; set; }
}