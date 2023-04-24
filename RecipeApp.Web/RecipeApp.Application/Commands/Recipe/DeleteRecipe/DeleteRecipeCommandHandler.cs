using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.RecipeN.DeleteRecipeService;

namespace RecipeApp.Application.Commands.RecipeN.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, bool>
    {
        private readonly IDeleteRecipeService _deleteRecipeService;
        private readonly ILogger _logger;

        public DeleteRecipeCommandHandler(
            IDeleteRecipeService deleteRecipeService,
            ILoggerFactory loggerFactory)
        {
            _deleteRecipeService = deleteRecipeService;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteRecipeCommandHandler));
        }

        public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete recipe request");
            ArgumentNullException.ThrowIfNull(request);

            return await _deleteRecipeService.DeleteRecipeAsync(request.RecipeId, request.UserId);
        }
    }
}
