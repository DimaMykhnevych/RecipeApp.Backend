using Microsoft.Extensions.DependencyInjection;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.NutrientIngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeIngredientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.RecipeStepRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeStepRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.IngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientRepository;
using RecipeApp.Infrastructure.Persistance.Repositories.NutrientIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;
using RecipeApp.Seeding.Configuration;
using Microsoft.EntityFrameworkCore;

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
                .AddTransient<INutrientIngredientRepository, NutrientIngredientRepository>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            string connectionString = new SecretAppsettingReader().ReadSection<string>("ConnectionStrings:Default");
            return serviceCollection.AddDbContext<RecipeAppDbContext>(opt =>
                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
