using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.RecipeN.CookRecipeService;

namespace RecipeApp.Application.Commands.RecipeN.CookRecipe
{
    public class CookRecipeCommandHandler : IRequestHandler<CookRecipeCommand, bool>
    {
        private readonly ICookRecipeService _cookRecipeService;
        private readonly ILogger _logger;

        public CookRecipeCommandHandler(
            ICookRecipeService cookRecipeService,
            ILoggerFactory loggerFactory)
        {
            _cookRecipeService = cookRecipeService;
            _logger = loggerFactory?.CreateLogger(nameof(CookRecipeCommandHandler));
        }

        public async Task<bool> Handle(CookRecipeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling cook recipe request");
            ArgumentNullException.ThrowIfNull(request);

            return await _cookRecipeService.CookRecipeAsync(request.AppUserId, request.RecipeId);
        }
    }
}
