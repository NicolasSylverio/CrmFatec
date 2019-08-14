using AutoFixture;
using Crm.Domain.Services;
using Moq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Crm.Domain.Interfaces.Abstraction;
using Xunit;

namespace Crm.Test
{
    public class EmailServiceTest
    {
        private readonly EmailService _emailService;        
        private readonly Fixture _fixture;

        private Mock<ISmtpClient> _smtpClientMock2;
        private Mock<SmtpClient> _smtpClientMock;
        private MailMessage _invalideMailMessage;
        private MailMessage _validMailMessage;

        private const string Host = "smtp.mailtrap.test";
        private const string CredencialsUserName = "";
        private const string CredentialsPassword = "";
        private const int Port = 2525;
        private const string From = "nicolas@fatec.com";

        public EmailServiceTest()
        {
            _fixture = new Fixture();

            _smtpClientMock = new Mock<SmtpClient>();

            ConfigureSmtp();
            ConfigureEmail();

            var emailService = _smtpClientMock.Object;
            emailService.Host = _fixture.Create<string>();
            emailService.Credentials = new NetworkCredential(_fixture.Create<string>(), _fixture.Create<string>());
            emailService.EnableSsl = true;
            emailService.Port = _fixture.Create<int>();            

            _emailService = new EmailService(_smtpClientMock.Object);
        }

        private void ConfigureSmtp()
        {

        }

        private void ConfigureEmail()
        {
            _validMailMessage = new MailMessage
            {                
                Body = "body",
                From = new MailAddress("teste@teste.com"),
                Subject = "subject",
                To = { new MailAddress("teste@teste.com") }
            };
        }

        [Fact]
        public void Deve_Enviar_EmailMessage()
        {
            var result = _emailService.SendEmail(_validMailMessage);

            Assert.Equal(Task.CompletedTask, result);

            _smtpClientMock.Verify(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [InlineData("teste@teste.com","subject","message")]
        public void Deve_Enviar_Email_Composto(string email, string subject, string message)
        {
            var result = _emailService.SendEmail(email, subject, message);

            Assert.Equal(Task.CompletedTask, result);

            _smtpClientMock.Verify(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}