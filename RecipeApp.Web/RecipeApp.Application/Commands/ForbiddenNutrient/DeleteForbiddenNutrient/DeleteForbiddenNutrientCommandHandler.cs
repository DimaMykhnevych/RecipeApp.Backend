using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.ForbiddenNutrientN.DeleteForbiddenNutrientService;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.DeleteForbiddenNutrient
{
    public class DeleteForbiddenNutrientCommandHandler : IRequestHandler<DeleteForbiddenNutrientCommand, bool>
    {
        private readonly IDeleteForbiddenNutrientService _deleteForbiddenNutrientService;
        private readonly ILogger _logger;

        public DeleteForbiddenNutrientCommandHandler(
            IDeleteForbiddenNutrientService deleteForbiddenNutrientService,
            ILoggerFactory loggerFactory)
        {
            _deleteForbiddenNutrientService = deleteForbiddenNutrientService;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteForbiddenNutrientCommandHandler));
        }

        public async Task<bool> Handle(DeleteForbiddenNutrientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete forbidden nutrient request");
            ArgumentNullException.ThrowIfNull(request);

            return await _deleteForbiddenNutrientService.DeleteForbiddenNutrientAsync(request.AppUserId, request.ForbiddenNutrientId);
        }
    }
}
