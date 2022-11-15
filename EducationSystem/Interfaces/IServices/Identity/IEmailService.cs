namespace EducationSystem.Interfaces.IServices.Identity;

public interface IEmailService
{
    Task<bool> SendMessageAsync(string receiverEmail, string subject, string body);
}