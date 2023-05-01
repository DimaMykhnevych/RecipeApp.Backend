using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Services.ForbiddenIngredientN.DeleteForbiddenIngredientService;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.DeleteForbiddenIngredient
{
    public class DeleteForbiddenIngredientCommandHandler : IRequestHandler<DeleteForbiddenIngredientCommand, bool>
    {
        private readonly IDeleteForbiddenIngredientService _deleteForbiddenIngredientService;
        private readonly ILogger _logger;

        public DeleteForbiddenIngredientCommandHandler(
            IDeleteForbiddenIngredientService deleteForbiddenIngredientService,
            ILoggerFactory loggerFactory)
        {
            _deleteForbiddenIngredientService = deleteForbiddenIngredientService;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteForbiddenIngredientCommandHandler));
        }

        public async Task<bool> Handle(DeleteForbiddenIngredientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete forbidden ingredient request");
            ArgumentNullException.ThrowIfNull(request);

            return await _deleteForbiddenIngredientService.DeleteForbiddenIngredientAsync(request.AppUserId, request.ForbiddenIngredientId);
        }
    }
}
