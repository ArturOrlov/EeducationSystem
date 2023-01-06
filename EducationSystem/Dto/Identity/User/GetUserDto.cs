using EducationSystem.Dto.Identity.UserInfo;

namespace EducationSystem.Dto.Identity.User;

public class GetUserDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public GetUserInfoDto UserInfo { get; set; }
}