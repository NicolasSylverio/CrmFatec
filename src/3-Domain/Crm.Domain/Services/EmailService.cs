using Crm.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Crm.Domain.Services
{
    /// <inheritdoc />
    public class EmailService : IEmailService
    {
        private const string Host = "smtp.mailtrap.io";
        private const string CredencialsUserName = "9f060dd0b0263b";
        private const string CredentialsPassword = "22d02ee66e21ff";
        private const int Port = 2525;
        private const string From = "nicolas@fatec.com";

        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient = null)
        {
            if (smtpClient == null)
            {
                _smtpClient = new SmtpClient
                {
                    Host = Host,
                    Credentials = new NetworkCredential(CredencialsUserName, CredentialsPassword),
                    EnableSsl = true,
                    Port = Port
                };
            }
            else
            {
                _smtpClient = smtpClient;
            }
        }

        public Task SendEmail(string email, string subject, string message)
        {
            return SendEmailByProperties(email, subject, message);
        }

        public Task SendEmail(MailMessage mailMessage)
        {
            return SendEmailByProperties(mailMessage);
        }

        public Task SendEmailAsync(string email, string subject, string message, object userToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEmailAsync(MailMessage emailMessage, object userToken)
        {
            throw new System.NotImplementedException();
        }

        private Task SendEmailByProperties(MailMessage emailMessage)
        {
            _smtpClient.Send(emailMessage);

            return Task.CompletedTask;
        }

        private Task SendEmailByProperties(string email, string subject, string message)
        {
            _smtpClient.Send(From, email, subject, message);

            return Task.CompletedTask;
        }
    }
}