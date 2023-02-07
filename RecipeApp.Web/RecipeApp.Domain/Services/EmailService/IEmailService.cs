using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.EmailService
{
    public interface IEmailService
    {
        Task SendAccountConfirmationEmail(AppUser receiver, string url);
    }
}
