using AdminPanelService.Service.Interfaces;
using AdminPanelService.Service.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace AdminPanelService.Service.Internal
{
    internal class EmailService : IEmailService
    {
        private Email _emailSettings;

        public EmailService(IOptions<Email> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string message, string subject)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.ValueFromEmail, _emailSettings.From));
            emailMessage.To.Add(new MailboxAddress(string.Empty,toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, false);
            await client.AuthenticateAsync(_emailSettings.User, _emailSettings.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
