using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService;

namespace RecipeApp.Application.Commands.RecipeN.AddRecipe
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, bool>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IAddRecipeNutritionService _addRecipeNutritionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddRecipeCommandHandler(
            IRecipeRepository recipeRepository,
            IAddRecipeNutritionService addRecipeNutritionService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
            _addRecipeNutritionService = addRecipeNutritionService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(AddRecipeCommandHandler));
        }

        public async Task<bool> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add recipe request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                Recipe recipe = _mapper.Map<Recipe>(request.Recipe);
                recipe.AppUserId = request.UserId;
                Recipe addedRecipe = await _recipeRepository.Insert(recipe);
                await _recipeRepository.Save();

                await _addRecipeNutritionService.AddRecipeNutrition(addedRecipe.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during adding recipe");
                return false;
            }
        }
    }
}
