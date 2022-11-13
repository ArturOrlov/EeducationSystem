namespace EducationSystem.Dto;

public class ChangePasswordRequest
{
    public string Token { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}