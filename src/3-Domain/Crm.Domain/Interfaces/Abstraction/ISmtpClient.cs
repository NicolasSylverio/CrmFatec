using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Crm.Domain.Interfaces.Abstraction
{
    public interface ISmtpClient
    {
        void Send(string from, string email, string subject, string message);

        void SendAsync(string from, string email, string subject, string message, object userToken);

        void Send(MailMessage mailMessage);

        void SendAsync(MailMessage mailMessage, object userToken);
    }
}