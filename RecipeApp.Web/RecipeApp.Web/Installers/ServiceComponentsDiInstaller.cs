using RecipeApp.Application.Factories;
using RecipeApp.Application.Services.AuthorizationService;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.NutrientIngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeIngredientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.RecipeStepRepository;
using RecipeApp.Domain.Services.AppLogs.GetLogs;
using RecipeApp.Domain.Services.DbManagement.CreateBackup;
using RecipeApp.Domain.Services.DbManagement.RestoreDb;
using RecipeApp.Domain.Services.Email.SendEmail;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;
using RecipeApp.Domain.Services.User.CreateUser;
using RecipeApp.Infrastructure.Persistance.Builders;
using RecipeApp.Infrastructure.Persistance.Repositories.ExternalUserRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.IngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeStepRepository;
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
            services.AddTransient<IExternalUserQueryBuilder, ExternalUserQueryBuilder>();
            services.AddTransient<IAppUserQueryBuilder, AppUserQueryBuilder>();

            // repositories
            services.AddTransient<IExternalUserRepository, ExternalUserRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeStepRepository, RecipeStepRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddTransient<INutrientRepository, NutrientRepository>();
            services.AddTransient<INutrientIngredientRepository, NutrientIngredientRepository>();

            //clients
            services.AddHttpClient<IRecognizeIngredientsService, RecognizeIngredientsService>();
        }
    }
}
