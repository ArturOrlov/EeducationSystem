namespace EducationSystem.Interfaces.IServices;

public interface IEmailService
{
    Task<bool> SendMessageAsync(string receiverEmail, string subject, string body);
}