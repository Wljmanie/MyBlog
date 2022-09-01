using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;

namespace MyBlog.Services
{
    public class EmailService : IBlogEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendContactMeEmailAsync(string emailFrom, string name, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.EmailNoReply));
            email.To.Add(MailboxAddress.Parse(_emailSettings.EmailContactMe));
            email.Subject = subject;

            var builder = new BodyBuilder()
            {
                HtmlBody = $"<b>{name}</b> has sent you an Contact Me email from the Blog and can be reached at: <b>{emailFrom}</b><br/><br/>{htmlMessage}"
            };
            
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_emailSettings.EmailNoReply, _emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.EmailNoReply));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;

            var builder = new BodyBuilder()
            {
                HtmlBody = htmlMessage
            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect); //was starttls
            smtp.Authenticate(_emailSettings.EmailNoReply, _emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
