using RecipeApp.Application.Commands.Auth;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Factories;
using RecipeApp.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RecipeApp.Application.Services.AuthorizationService
{
    public abstract class BaseAuthorizationService
    {
        private readonly IAuthTokenFactory _tokenFactory;
        public BaseAuthorizationService(IAuthTokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }
        public async Task<JWTTokenStatusResultDto> GenerateTokenAsync(SignInCommand model)
        {
            LoginErrorCodes status = await VerifyUserAsync(model);
            if (status != LoginErrorCodes.None)
            {
                return new JWTTokenStatusResultDto()
                {
                    Token = null,
                    IsAuthorized = false,
                    LoginErrorCode = status
                };
            }

            IEnumerable<Claim> claims = await GetUserClaimsAsync(model);
            JwtSecurityToken token = _tokenFactory.CreateToken(model.UserName.ToString(), claims);
            UserAuthInfoDto info = await GetUserInfoAsync(model.UserName);

            return new JWTTokenStatusResultDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                IsAuthorized = true,
                UserInfo = info,
                LoginErrorCode = LoginErrorCodes.None
            };
        }

        public abstract Task<IEnumerable<Claim>> GetUserClaimsAsync(SignInCommand model);
        public abstract Task<UserAuthInfoDto> GetUserInfoAsync(string userName);
        public abstract Task<LoginErrorCodes> VerifyUserAsync(SignInCommand model);
    }
}
