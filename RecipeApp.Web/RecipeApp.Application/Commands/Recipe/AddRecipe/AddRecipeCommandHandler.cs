using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeRepository;

namespace RecipeApp.Application.Commands.RecipeN.AddRecipe
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, bool>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddRecipeCommandHandler(
            IRecipeRepository recipeRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
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
                await _recipeRepository.Insert(recipe);
                await _recipeRepository.Save();
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
