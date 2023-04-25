using Microsoft.Extensions.Options;
using PAT.Common.Extensions;
using PAT.Models.Configuration;
using PAT.Provider.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Net.Mime;

namespace PAT.Provider.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
        => _emailSettings = emailSettings.Value;

    public async Task<EmailResponse> SendEmail(EmailData emailData)
    {
        try
        {
            var client = new SendGridClient(_emailSettings.SendGridApiKey);
            var msg = MailHelper.CreateSingleEmail(
                 new EmailAddress(_emailSettings.SendGridFrom),
                 new EmailAddress(emailData.EmailToName),
                 emailData.EmailSubject,
                 emailData.EmailBody,
                 emailData.EmailBody);
            var response = await client.SendEmailAsync(msg);
            return new(response.IsSuccessStatusCode, Enumerable.Empty<string>());
        }
        catch (Exception ex)
        {
            return new(false, ex.GetErrors());
            // TODO Martin Log Exception Details
        }
    }
}
