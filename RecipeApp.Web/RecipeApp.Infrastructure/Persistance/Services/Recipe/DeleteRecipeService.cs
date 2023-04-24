using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.RecipeN.DeleteRecipeService;

namespace RecipeApp.Infrastructure.Persistance.Services.RecipeN
{
    public class DeleteRecipeService : IDeleteRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger _logger;

        public DeleteRecipeService(
            IRecipeRepository recipeRepository,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteRecipeService));
        }

        public async Task<bool> DeleteRecipeAsync(int recipeId, int appUserId)
        {
            _logger.LogInformation("Deleting a recipe {RecipeId}", recipeId);
            try
            {
                var recipeToDelete = await _recipeRepository.Get(recipeId);
                if (recipeToDelete == null || recipeToDelete.AppUserId != appUserId)
                {
                    // AppUser can delete only recipes created by himself.
                    _logger.LogWarning("User {UserId} was trying to delete recipe he didn't create," +
                        " or recipe {RecipeId} dosen't exist", appUserId, recipeId);
                    return false;
                }

                await _recipeRepository.DeleteById(recipeId);
                await _recipeRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when deleting the recipe {RecipeId}", recipeId);
                return false;
            }
        }
    }
}
