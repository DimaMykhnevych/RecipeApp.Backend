using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Options;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.NutrientIngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeIngredientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.RecipeStepRepository;
using RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService;
using RecipeApp.Infrastructure.Persistance.Context;
using RecipeApp.Infrastructure.Persistance.Repositories.IngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeStepRepository;
using RecipeApp.Infrastructure.Persistance.Services.Recipe;
using RecipeApp.Seeding.Configuration;
using System.Text.Json;

namespace RecipeApp.Seeding.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IRecipeRepository, RecipeRepository>()
                .AddTransient<IRecipeStepRepository, RecipeStepRepository>()
                .AddTransient<IIngredientRepository, IngredientRepository>()
                .AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>()
                .AddTransient<INutrientRepository, NutrientRepository>()
                .AddTransient<INutrientIngredientRepository, NutrientIngredientRepository>()
                .AddTransient<INutrientRecipeRepository, NutrientRecipeRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IAddRecipeNutritionService, AddRecipeNutritionService>();
        }

        public static IServiceCollection AddRecipeApiOptions(this IServiceCollection serviceCollection)
        {
            var configOptions = SecretAppsettingReader.GetConfiguration();
            serviceCollection.Configure<RecipeApiOptions>(configOptions.GetSection("RecipeApi"));
            return serviceCollection;
        }

        public static IServiceCollection AddClients(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton(new HttpClient())
                .AddTransient<Domain.Clients.RecipeApiClient.IRecipeApiClient, Infrastructure.Persistance.Clients.RecipeApiClientN.RecipeApiClient>();
        }

        public static IServiceCollection AddLoggingServices(this IServiceCollection services)
        {
            return services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddLog4Net("log4net.config");
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
        }

        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            string connectionString = new SecretAppsettingReader().ReadSection<string>("ConnectionStrings:Default");
            return serviceCollection.AddDbContext<RecipeAppDbContext>(opt =>
                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
