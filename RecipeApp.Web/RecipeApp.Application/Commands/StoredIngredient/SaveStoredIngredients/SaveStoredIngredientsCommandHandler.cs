using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;

namespace RecipeApp.Application.Commands.StoredIngredient.SaveStoredIngredients
{
    public class SaveStoredIngredientsCommandHandler : IRequestHandler<SaveStoredIngredientsCommand, bool>
    {
        private readonly IStoredIngredientRepository _storedIngredientReporitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SaveStoredIngredientsCommandHandler(
            IStoredIngredientRepository storedIngredientReporitory,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _storedIngredientReporitory = storedIngredientReporitory;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(SaveStoredIngredientsCommandHandler));
        }

        public async Task<bool> Handle(SaveStoredIngredientsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling save stored ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            var storedIngredients = _mapper.Map<IEnumerable<Domain.Entities.StoredIngredient>>(request.StoredIngredients);
            try
            {
                foreach (var ingredient in storedIngredients)
                {
                    ingredient.AppUserId = request.UserId;
                    ingredient.LastModifiedDate = DateTime.Now;
                    await _storedIngredientReporitory.AddOrUpdateStoredIngredient(ingredient);
                }

                await _storedIngredientReporitory.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during saving users's stored ingredients");
                return false;
            }
        }
    }
}
