using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RecipeApp.Domain.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "Recipe.App.API";
        public const string AUDIENCE = "Recipe.App.User";
        private const string SECRET_KEY = "4HqoFK424mTaaV3rOWq3uBy0z3JVc8Yh";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));
        }
    }
}
