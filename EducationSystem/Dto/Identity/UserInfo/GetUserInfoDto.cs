namespace EducationSystem.Dto.Identity.UserInfo;

public class GetUserInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTimeOffset? Birthday { get; set; }
}