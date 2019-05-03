using Crm.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Crm.Domain.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // email service here
            return Task.FromResult(0);
        }
    }
}