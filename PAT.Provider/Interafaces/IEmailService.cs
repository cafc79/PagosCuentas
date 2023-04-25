using PAT.Provider.Models;

namespace PAT.Provider
{
    public interface IEmailService
    {
        Task<EmailResponse> SendEmail(EmailData emailData);
    }
}
