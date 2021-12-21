using AVS_Global_API.Models;

namespace AVS_Global_API.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}
