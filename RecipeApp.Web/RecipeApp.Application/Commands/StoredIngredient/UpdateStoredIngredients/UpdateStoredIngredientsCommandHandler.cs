using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;

namespace RecipeApp.Application.Commands.StoredIngredient.UpdateStoredIngredients
{
    public class UpdateStoredIngredientsCommandHandler : IRequestHandler<UpdateStoredIngredientsCommand, bool>
    {
        private readonly IStoredIngredientRepository _storedIngredientReporitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateStoredIngredientsCommandHandler(
            IStoredIngredientRepository storedIngredientReporitory,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _storedIngredientReporitory = storedIngredientReporitory;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateStoredIngredientsCommandHandler));
        }

        public async Task<bool> Handle(UpdateStoredIngredientsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling update stored ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                foreach (var storedIngredient in request.StoredIngredients)
                {
                    var existingStoredIngredient = await _storedIngredientReporitory.Get(storedIngredient.Id);
                    if (existingStoredIngredient == null)
                    {
                        continue;
                    }

                    existingStoredIngredient.ExpirationDate = storedIngredient.ExpirationDate;
                    existingStoredIngredient.Amount = storedIngredient.Amount;
                    existingStoredIngredient.LastModifiedDate = DateTime.Now;
                    await _storedIngredientReporitory.Update(existingStoredIngredient);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during updating users's stored ingredients");
                return false;
            }
        }
    }
}
