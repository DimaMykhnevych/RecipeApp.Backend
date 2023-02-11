using RecipeApp.Application.Factories;
using RecipeApp.Application.Services.AuthorizationService;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Services.AppLogs.GetLogs;
using RecipeApp.Domain.Services.DbManagement.CreateBackup;
using RecipeApp.Domain.Services.DbManagement.RestoreDb;
using RecipeApp.Domain.Services.Email.SendEmail;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;
using RecipeApp.Domain.Services.User.CreateUser;
using RecipeApp.Infrastructure.Persistance.Builders;
using RecipeApp.Infrastructure.Persistance.Services.AppLogs;
using RecipeApp.Infrastructure.Persistance.Services.DbManagement;
using RecipeApp.Infrastructure.Persistance.Services.FoodRecognition;

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
            services.AddTransient<IRestoreDbService, RestoreDbService>();
            services.AddTransient<ICreateBackupService, CreateBackupService>();

            // builders
            services.AddTransient<IUserQueryBuilder, UserQueryBuilder>();

            // repositories

            //clients
            services.AddHttpClient<IRecognizeIngredientsService, RecognizeIngredientsService>();
        }
    }
}
