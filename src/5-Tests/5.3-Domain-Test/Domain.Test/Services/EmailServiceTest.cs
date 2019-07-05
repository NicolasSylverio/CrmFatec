using System.Net.Mail;
using Crm.Domain.Interfaces.Services;
using Moq;
using System.Threading.Tasks;
using AutoFixture;
using Crm.Domain.Models.Services;
using Xunit;

namespace Domain.Test.Services
{
    public class EmailServiceTest
    {
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<SmtpClient> _smtpClientMock;
        private readonly IEmailService _emailService;
        private readonly Fixture _fixture;
        private readonly MailMessage _emailMessage;


        public EmailServiceTest()
        {
            _emailServiceMock = new Mock<IEmailService>();
            _smtpClientMock = new Mock<SmtpClient>();
            _emailService = _emailServiceMock.Object;
            _fixture = new Fixture();

            _emailMessage = new MailMessage("teste@teste.com", "teste@teste.com", "subject", "body");
        }

        [Fact]
        public void DeveEnviarEmail()
        {
            _smtpClientMock.Setup(x => x.Send(_emailMessage));

            var retorno = _emailService.SendEmailAsync(_emailMessage);

            Assert.Equal(Task.CompletedTask, retorno);

            _emailServiceMock.Verify(x => x.SendEmailAsync(It.IsAny<EmailMessage>()), Times.Once);
            _emailServiceMock.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
    }
}