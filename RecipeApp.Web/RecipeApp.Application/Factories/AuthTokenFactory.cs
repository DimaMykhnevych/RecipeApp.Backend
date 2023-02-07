using Microsoft.IdentityModel.Tokens;
using RecipeApp.Domain.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RecipeApp.Application.Factories
{
    public class AuthTokenFactory : IAuthTokenFactory
    {
        public JwtSecurityToken CreateToken(string username, IEnumerable<Claim> businessClaims)
        {
            return CreateToken(username, AuthOptions.GetSymmetricSecurityKey(), AuthOptions.ISSUER, AuthOptions.AUDIENCE, businessClaims);
        }

        public JwtSecurityToken CreateToken(string username, SymmetricSecurityKey secret, String issuer, String audience, IEnumerable<Claim> businessClaims)
        {
            List<Claim> claims = new ()
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
            };

            claims.AddRange(businessClaims);

            SigningCredentials signinCredentials = new (secret, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new (
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signinCredentials);

            return jwtSecurityToken;
        }
    }
}
