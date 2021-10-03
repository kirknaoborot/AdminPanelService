using System.Threading.Tasks;

namespace AdminPanelService.Service.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string message, string subject);
    }
}
