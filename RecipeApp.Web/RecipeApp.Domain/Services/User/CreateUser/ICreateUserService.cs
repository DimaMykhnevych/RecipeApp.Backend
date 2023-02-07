using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.User.CreateUser
{
    public interface ICreateUserService
    {
        Task<AppUser> CreateUserAsync(AppUser userModel, string password, string confirmPassword, string clientURIForEmailConfirmation);
    }
}
