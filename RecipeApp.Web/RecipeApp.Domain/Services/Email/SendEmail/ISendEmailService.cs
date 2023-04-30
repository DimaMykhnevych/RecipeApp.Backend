using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.Email.SendEmail
{
    public interface ISendEmailService
    {
        Task SendAccountConfirmationEmail(AppUser receiver, string url);
        Task SendStoredIngredientExpirationEmail(AppUser receiver, IEnumerable<StoredIngredient> expiredIngredeints);
    }
}
