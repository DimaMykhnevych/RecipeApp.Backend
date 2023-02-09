using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Models;
using RecipeApp.Web.Options;

namespace RecipeApp.Web.Installers
{
    public class OptionsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MySqlConfigOptions>(configuration.GetSection(ConfigurationKeys.ConnectionStrings));
            services.Configure<EmailServiceOptions>(configuration.GetSection(ConfigurationKeys.EmailServiceOptions));
        }
    }
}
