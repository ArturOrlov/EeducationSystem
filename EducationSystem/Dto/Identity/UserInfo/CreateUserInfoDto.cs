namespace EducationSystem.Dto.Identity.UserInfo;

public class CreateUserInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime? Birthday { get; set; }
}