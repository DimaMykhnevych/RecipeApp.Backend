using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.AddForbiddenIngredient
{
    public class AddForbiddenIngredientCommandHandler : IRequestHandler<AddForbiddenIngredientCommand, bool>
    {
        private readonly IForbiddenIngredientRepository _forbiddenIngredientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddForbiddenIngredientCommandHandler(
            IForbiddenIngredientRepository forbiddenIngredientRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _forbiddenIngredientRepository = forbiddenIngredientRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(AddForbiddenIngredientCommandHandler));
        }

        public async Task<bool> Handle(AddForbiddenIngredientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add forbidden ingredient request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                ForbiddenIngredient forbiddenIngredient = new()
                {
                    AppUserId = request.AppUserId,
                    IngredientId = request.ForbiddenIngredient.IngredientId
                };

                await _forbiddenIngredientRepository.Insert(forbiddenIngredient);
                await _forbiddenIngredientRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during saving users's forbidden request" +
                    " (IngredientId: {IngredientId}, UserId: {UserId})", request.ForbiddenIngredient.IngredientId, request.AppUserId);
                return false;
            }
        }
    }
}
