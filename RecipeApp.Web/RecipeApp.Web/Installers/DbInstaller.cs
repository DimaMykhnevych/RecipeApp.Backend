using Microsoft.EntityFrameworkCore;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Web.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:Default"];
            services.AddDbContext<RecipeAppDbContext>(opt =>
                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
