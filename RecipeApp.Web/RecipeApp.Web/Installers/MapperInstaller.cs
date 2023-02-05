using RecipeApp.Application.Mappers;

namespace RecipeApp.Web.Installers
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
