using Microsoft.Extensions.Configuration;

namespace RecipeApp.Seeding.Configuration
{
    internal class SecretAppsettingReader
    {
        public T ReadSection<T>(string sectionName)
        {
            var configurationRoot = GetConfiguration();
            return configurationRoot.GetSection(sectionName).Get<T>();
        }

        public static IConfiguration GetConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
