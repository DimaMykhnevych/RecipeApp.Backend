using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Services.ForbiddenIngredientN.AddForbiddenIngredientService;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.AddForbiddenIngredient
{
    public class AddForbiddenIngredientCommandHandler : IRequestHandler<AddForbiddenIngredientCommand, bool>
    {
        private readonly IAddForbiddenIngredientService _addForbiddenIngredientService;
        private readonly ILogger _logger;

        public AddForbiddenIngredientCommandHandler(
            IAddForbiddenIngredientService addForbiddenIngredientService,
            ILoggerFactory loggerFactory)
        {
            _addForbiddenIngredientService = addForbiddenIngredientService;
            _logger = loggerFactory?.CreateLogger(nameof(AddForbiddenIngredientCommandHandler));
        }

        public async Task<bool> Handle(AddForbiddenIngredientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add forbidden ingredient request");
            ArgumentNullException.ThrowIfNull(request);

            return await _addForbiddenIngredientService.AddForbiddenIngredientAsync(
                request.AppUserId,
                new ForbiddenIngredient()
                {
                    IngredientId = request.ForbiddenIngredient.IngredientId,
                    ExternalUserId = request.ForbiddenIngredient.ExternalUserId,
                });
        }
    }
}
