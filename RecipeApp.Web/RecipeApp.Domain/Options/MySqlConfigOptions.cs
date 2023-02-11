using Microsoft.Extensions.Configuration;

namespace RecipeApp.Domain.Options
{
    public class MySqlConfigOptions
    {
        [ConfigurationKeyName("Default")]
        public string DefaultConnectionString { get; set; }
    }
}
