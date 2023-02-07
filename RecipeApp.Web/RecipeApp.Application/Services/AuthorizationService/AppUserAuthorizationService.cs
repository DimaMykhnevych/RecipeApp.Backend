using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RecipeApp.Application.Commands.Auth.SignIn;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Factories;
using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Enums;
using RecipeApp.Domain.Extensions;
using System.Security.Claims;

namespace RecipeApp.Application.Services.AuthorizationService
{
    public class AppUserAuthorizationService : BaseAuthorizationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AppUserAuthorizationService(
            IAuthTokenFactory tokenFactory,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration configuration)
            : base(tokenFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public override async Task<IEnumerable<Claim>> GetUserClaimsAsync(SignInCommand model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new List<Claim> { };
            }

            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(AuthorizationConstants.ID, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        public async override Task<LoginErrorCodes> VerifyUserAsync(SignInCommand model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return LoginErrorCodes.InvalidUsernameOrPassword;
            }

            if (_configuration.EmailConfirmationEnabled() && !await _userManager.IsEmailConfirmedAsync(user))
            {
                return LoginErrorCodes.EmailConfirmationRequired;
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            return result.Succeeded ? LoginErrorCodes.None : LoginErrorCodes.InvalidUsernameOrPassword;
        }

        public async override Task<UserAuthInfoDto> GetUserInfoAsync(string userName)
        {
            if (userName == null) return null;
            AppUser user = await _userManager.FindByNameAsync(userName);

            UserAuthInfoDto info = new ()
            {
                Role = user.Role,
                UserId = user.Id,
                UserName = user.UserName,
                RegistryDate = user.RegistryDate,
                Email = user.Email
            };

            return info;
        }
    }
}
