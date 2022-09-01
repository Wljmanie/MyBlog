using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyBlog.Services.Interfaces
{
    public interface IBlogEmailSender : IEmailSender
    {
        Task SendContactMeEmailAsync(string emailFrom, string name, string subject, string htmlMessage);
    }
}
