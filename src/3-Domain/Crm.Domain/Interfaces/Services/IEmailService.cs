using System.Net.Mail;
using System.Threading.Tasks;

namespace Crm.Domain.Interfaces.Services
{
    /// <summary>
    /// Abstração para envio de mensagens de Email.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Envia e-mails de forma sincrona, compondo e-mail padrão com os parametros passados.
        /// </summary>s
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmail(string email, string subject, string message);

        /// <summary>
        /// Envia e-mails de forma sincrona, envia o e-mail passado pelo parametro do tipo MailMessage.
        /// </summary>
        /// <param name="emailMessage">E-mail para ser enviado</param>
        /// <returns></returns>
        Task SendEmail(MailMessage emailMessage);

        /// <summary>
        /// Envia e-mail de forma assincrona, compondo e-mail padrão com os parametros passados.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message, object userToken);

        /// <summary>
        /// Envia e-mail de forma assincrona, envia o e-mail passado pelo parametro do tipo MailMessage.
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task SendEmailAsync(MailMessage emailMessage, object userToken);
    }
}