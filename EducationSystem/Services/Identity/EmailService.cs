using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using EducationSystem.Interfaces.IServices.Identity;

namespace EducationSystem.Services.Identity;

public class EmailService : IEmailService
{
    private readonly ISettingService _settings;
        
    public EmailService(ISettingService settings)
    {
        _settings = settings;
    }

    public async Task<bool> SendMessageAsync(string receiverEmail, string subject, string body)
    {
        var emailSendSettings = await _settings.GetEmailSendData();

        if (emailSendSettings == null)
        {
            return false;
        }
            
        try
        {
            var message = new MailMessage(emailSendSettings.EmailAddress, receiverEmail, subject, body);
                
            using (var client = new SmtpClient(emailSendSettings.SmtpClient)) // используем сервера Google
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(emailSendSettings.EmailAddress, emailSendSettings.Password); // логин-пароль от аккаунта
                client.Port = emailSendSettings.Port;  // порт 587 либо 465
                client.EnableSsl = true; // SSL обязательно
                client.Send(message);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
        
    private AlternateView GetEmbeddedImage(string filePath)
    {
        var res = new LinkedResource(@"wwwroot\" + filePath, MediaTypeNames.Image.Jpeg);  
        res.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
        var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
            null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(res);
        return alternateView;
    }
}