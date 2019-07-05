using System.Net.Mail;

namespace Crm.Domain.Models.Services
{
    public class EmailMessage : MailMessage
    {
        public EmailMessage
        (
            string From,
            string To,
            string subject,
            string body,
            MailPriority mailPriority = MailPriority.Normal,
            bool IsHtmlBody = true
        )
        : base(From, To, subject, body)
        {
            Priority = mailPriority;
            IsBodyHtml = IsHtmlBody;
        }
    }
}