namespace EducationSystem.Dto.Identity.UserInfo;

public class UpdateUserInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime? Birthday { get; set; }
}