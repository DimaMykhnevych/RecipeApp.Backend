using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Exceptions;
using RecipeApp.Domain.Extensions;
using RecipeApp.Domain.Services.EmailService;

namespace RecipeApp.Domain.Services.UserService
{
    public class CreateUserService : ICreateUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public CreateUserService(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<AppUser> CreateUserAsync(AppUser user, string password, string confirmPassword, string clientURIForEmailConfirmation)
        {
            if (password != confirmPassword)
            {
                throw new PasswordsMismatchException();
            }

            AppUser existingUser = await _userManager.FindByNameAsync(user.UserName);
            if (existingUser != null)
            {
                throw new UsernameAlreadyTakenException();
            }

            user.RegistryDate = DateTime.Now;
            IdentityResult addUserResult = await _userManager.CreateAsync(user, password);

            addUserResult.ValidateIdentityResult();

            if (_configuration.EmailConfirmationEnabled())
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var param = new Dictionary<string, string>
                {
                    {"token", token },
                    {"email", user.Email }
                };
                string url = QueryHelpers.AddQueryString(clientURIForEmailConfirmation, param);
                await _emailService.SendAccountConfirmationEmail(user, url);
            }

            return await _userManager.FindByNameAsync(user.UserName);
        }
    }
}
