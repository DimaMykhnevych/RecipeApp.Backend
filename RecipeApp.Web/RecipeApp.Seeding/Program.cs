using Microsoft.Extensions.DependencyInjection;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService;
using RecipeApp.Seeding.ApiClients;
using RecipeApp.Seeding.ApiModels;
using RecipeApp.Seeding.Extensions;
using RecipeApp.Seeding.Mocks;
using RecipeApp.Seeding.Services;

var serviceProvider = new ServiceCollection()
    .AddRecipeApiOptions()
    .AddLoggingServices()
    .AddClients()
    .AddDatabase()
    .AddRepositories()
    .AddServices()
    .BuildServiceProvider();

IRecipeApiClient internalRecipeApiClient = new RecipeApiClient(new HttpClient());
IRecipeApiClient internalRecipeApiClientMock = new RecipeApiClientMock();
AddRecipeService addRecipeService = new(
    internalRecipeApiClient,
    serviceProvider.GetService<IRecipeRepository>(),
    serviceProvider.GetService<IIngredientRepository>(),
    serviceProvider.GetService<INutrientRepository>(),
    serviceProvider.GetService<IAddRecipeNutritionService>()
    );

int recipesAmount = 1;

for (int i = 0; i < recipesAmount; i++)
{
    Console.WriteLine($"Adding recipe #{i}");
    Random random = new();
    int id = random.Next(1, 756814);
    RecipeDto recipe = await internalRecipeApiClient.GetRecipeInfo(id);
    if (recipe == null)
    {
        continue;
    }
    try
    {
        await addRecipeService.AddRecipe(recipe);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unhandled exception: {ex.Message}");
    }
}
