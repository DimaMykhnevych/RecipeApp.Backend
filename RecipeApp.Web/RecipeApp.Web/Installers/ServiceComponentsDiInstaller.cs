using RecipeApp.Application.Factories;
using RecipeApp.Application.Services.AuthorizationService;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Services.AppLogs.GetLogs;
using RecipeApp.Domain.Services.Email.SendEmail;
using RecipeApp.Domain.Services.User.CreateUser;
using RecipeApp.Infrastructure.Persistance.Builders;
using RecipeApp.Infrastructure.Persistance.Services.AppLogs;

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
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<ICreateUserService, CreateUserService>();
            services.AddTransient<IGetLogsService, GetLogsService>();

            // builders
            services.AddTransient<IUserQueryBuilder, UserQueryBuilder>();

            // repositories
        }
    }
}
