using RecipeApp.Application.Factories;
using RecipeApp.Application.Services.AuthorizationService;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Clients.RecipeApiClient;
using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyMemberRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.MealPlanRepository;
using RecipeApp.Domain.Repositories.NutrientIngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeIngredientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.RecipeStepRepository;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Domain.Services.AppLogs.GetLogs;
using RecipeApp.Domain.Services.DbManagement.CreateBackup;
using RecipeApp.Domain.Services.DbManagement.RestoreDb;
using RecipeApp.Domain.Services.Email.SendEmail;
using RecipeApp.Domain.Services.Family.DeleteFamilyService;
using RecipeApp.Domain.Services.Family.UpdateFamilyService;
using RecipeApp.Domain.Services.FamilyMemberN.AddFamilyMemberService;
using RecipeApp.Domain.Services.FamilyMemberN.DeleteFamilyMemberService;
using RecipeApp.Domain.Services.FamilyMemberN.UpdateFamilyMemberService;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;
using RecipeApp.Domain.Services.ForbiddenIngredientN.AddForbiddenIngredientService;
using RecipeApp.Domain.Services.ForbiddenIngredientN.DeleteForbiddenIngredientService;
using RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService;
using RecipeApp.Domain.Services.RecipeN.AddRecipeNutritionService;
using RecipeApp.Domain.Services.RecipeN.DeleteRecipeService;
using RecipeApp.Domain.Services.RecipeN.IncludeIngredientsService;
using RecipeApp.Domain.Services.User.CreateUser;
using RecipeApp.Infrastructure.Persistance.Builders;
using RecipeApp.Infrastructure.Persistance.Clients.RecipeApiClientN;
using RecipeApp.Infrastructure.Persistance.Context;
using RecipeApp.Infrastructure.Persistance.Repositories.ExternalUserRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.FamilyMemberRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.FamilyRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.IngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.MealPlanRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeStepRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.StoredIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Services.AppLogs;
using RecipeApp.Infrastructure.Persistance.Services.DbManagement;
using RecipeApp.Infrastructure.Persistance.Services.Family;
using RecipeApp.Infrastructure.Persistance.Services.FamilyMemberN;
using RecipeApp.Infrastructure.Persistance.Services.FoodRecognition;
using RecipeApp.Infrastructure.Persistance.Services.ForbiddenIngredientN;
using RecipeApp.Infrastructure.Persistance.Services.MealPlanN;
using RecipeApp.Infrastructure.Persistance.Services.RecipeN;
using RecipeApp.Infrastructure.Persistance.Services.StoredIngredientN;

namespace RecipeApp.Web.Installers
{
    public class ServiceComponentsDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // contexts
            services.AddScoped<IRecipeAppDbContext, RecipeAppDbContext>();

            // factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            // services
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<ICreateUserService, CreateUserService>();
            services.AddTransient<IGetLogsService, GetLogsService>();
            services.AddTransient<IRestoreDbService, RestoreDbService>();
            services.AddTransient<ICreateBackupService, CreateBackupService>();
            services.AddTransient<IIncludeIngredientsService, IncludeIngredientsService>();
            services.AddTransient<IUpdateFamilyService, UpdateFamilyService>();
            services.AddTransient<IDeleteFamilyService, DeleteFamilyService>();
            services.AddTransient<IAddFamilyMemberService, AddFamilyMemberService>();
            services.AddTransient<IUpdateFamilyMemberService, UpdateFamilyMemberService>();
            services.AddTransient<IDeleteFamilyMemberService, DeleteFamilyMemberService>();
            services.AddTransient<IMealPlanRecommendationService, MealPlanRecommendationService>();
            services.AddTransient<IAddRecipeNutritionService, AddRecipeNutritionService>();
            services.AddTransient<IDeleteRecipeService, DeleteRecipeService>();
            services.AddTransient<IAddForbiddenIngredientService, AddForbiddenIngredientService>();
            services.AddTransient<IDeleteForbiddenIngredientService, DeleteForbiddenIngredientService>();

            // hosted services
            if (bool.TryParse(configuration[ConfigurationKeys.SendIngredientsExpirationEmails], out bool sendEmails) && sendEmails)
            {
                services.AddHostedService<MonitorStoredIngredientService>();
            }

            // builders
            services.AddTransient<IExternalUserQueryBuilder, ExternalUserQueryBuilder>();
            services.AddTransient<IAppUserQueryBuilder, AppUserQueryBuilder>();
            services.AddTransient<IRecipeQueryBuilder, RecipeQueryBuilder>();
            services.AddTransient<IMealPlanQueryBuilder, MealPlanQueryBuilder>();

            // repositories
            services.AddTransient<IExternalUserRepository, ExternalUserRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeStepRepository, RecipeStepRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddTransient<INutrientRepository, NutrientRepository>();
            services.AddTransient<INutrientIngredientRepository, NutrientIngredientRepository>();
            services.AddTransient<IStoredIngredientRepository, StoredIngredientRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
            services.AddTransient<IFamilyMemberRepository, FamilyMemberRepository>();
            services.AddTransient<IForbiddenNutrientRepository, ForbiddenNutrientRepository>();
            services.AddTransient<INutrientRecipeRepository, NutrientRecipeRepository>();
            services.AddTransient<IMealPlanRepository, MealPlanRepository>();
            services.AddTransient<IForbiddenIngredientRepository, ForbiddenIngredientRepository>();

            //clients
            services.AddHttpClient<IRecognizeIngredientsService, RecognizeIngredientsService>();
            services.AddHttpClient<IRecipeApiClient, RecipeApiClient>();
        }
    }
}
