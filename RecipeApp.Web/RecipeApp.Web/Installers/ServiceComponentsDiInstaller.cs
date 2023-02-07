using RecipeApp.Application.Factories;
using RecipeApp.Application.Services.AuthorizationService;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Services.EmailService;
using RecipeApp.Domain.Services.UserService;
using RecipeApp.Infrastructure.Persistance.Builders;

namespace RecipeApp.Web.Installers
{
    public class ServiceComponentsDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            // services
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICreateUserService, CreateUserService>();

            // builders
            services.AddTransient<IUserQueryBuilder, UserQueryBuilder>();

            // repositories
        }
    }
}
