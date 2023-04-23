using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService;

namespace RecipeApp.Application.Commands.RecipeN.AddRecipeNutrition
{
    public class AddRecipeNutritionCommandHandler : IRequestHandler<AddRecipeNutritionCommand, bool>
    {
        private readonly IAddRecipeNutritionService _addRecipeNutritionService;
        private readonly ILogger _logger;

        public AddRecipeNutritionCommandHandler(
            IAddRecipeNutritionService addRecipeNutritionService,
            ILoggerFactory loggerFactory)
        {
            _addRecipeNutritionService = addRecipeNutritionService;
            _logger = loggerFactory?.CreateLogger(nameof(AddRecipeNutritionCommandHandler));
        }

        public async Task<bool> Handle(AddRecipeNutritionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add recipe nutrition request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                await _addRecipeNutritionService.AddRecipeNutrition(request.RecipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during adding recipe nutrition");
                return false;
            }
        }
    }
}
