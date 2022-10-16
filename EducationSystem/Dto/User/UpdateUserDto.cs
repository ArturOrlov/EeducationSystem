using EducationSystem.Dto.UserInfo;

namespace EducationSystem.Dto.User;

public class UpdateUserDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    
    public UpdateUserInfoDto UserInfo { get; set; }
}