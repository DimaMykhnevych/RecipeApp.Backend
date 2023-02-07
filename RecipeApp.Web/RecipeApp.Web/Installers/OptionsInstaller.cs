using RecipeApp.Domain.Models;
using RecipeApp.Web.Options;

namespace RecipeApp.Web.Installers
{
    public class OptionsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MySqlConfigOptions>(configuration.GetSection("ConnectionStrings:Default"));
            services.Configure<EmailServiceOptions>(configuration.GetSection("EmailServiceOptions"));
        }
    }
}
