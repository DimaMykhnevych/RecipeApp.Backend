using MediatR;
using RecipeApp.Application;

namespace RecipeApp.Web.Installers
{
    public class MediatorInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AssemblyInfo));
        }
    }
}
