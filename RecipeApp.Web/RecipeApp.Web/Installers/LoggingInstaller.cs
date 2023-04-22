using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using RecipeApp.Domain.Constants;

namespace RecipeApp.Web.Installers
{
    public class LoggingInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddLog4Net("log4net.config");
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                ConnectionString = configuration[ConfigurationKeys.ApplicationInsightsConnectionString],
                EnableActiveTelemetryConfigurationSetup = true
            });
        }
    }
}
