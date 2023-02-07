using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.Email.SendEmail
{
    public interface IEmailService
    {
        Task SendAccountConfirmationEmail(AppUser receiver, string url);
    }
}
