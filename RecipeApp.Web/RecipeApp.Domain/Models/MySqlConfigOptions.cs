using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace RecipeApp.Web.Options
{
    public class MySqlConfigOptions
    {
        [ConfigurationKeyName("Default")]
        public string DefaultConnectionString { get; set; }
    }
}
