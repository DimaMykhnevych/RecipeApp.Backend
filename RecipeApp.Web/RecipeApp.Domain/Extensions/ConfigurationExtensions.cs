using Microsoft.Extensions.Configuration;
using RecipeApp.Domain.Constants;

namespace RecipeApp.Domain.Extensions
{
    public static class ConfigurationExtensions
    {
        public static bool EmailConfirmationEnabled(this IConfiguration configuration)
        {
            return bool.TryParse(configuration[ConfigurationKeys.EmailConfirmationEnabled], out bool result) && result;
        }
    }
}
