using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;

namespace RecipeApp.Application.Commands.StoredIngredient.DeleteStoredIngredients
{
    public class DeleteStoredIngredientsCommandHandler : IRequestHandler<DeleteStoredIngredientsCommand, bool>
    {
        private readonly IStoredIngredientRepository _storedIngredientReporitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteStoredIngredientsCommandHandler(
            IStoredIngredientRepository storedIngredientReporitory,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _storedIngredientReporitory = storedIngredientReporitory;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteStoredIngredientsCommandHandler));
        }

        public async Task<bool> Handle(DeleteStoredIngredientsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete stored ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                foreach (var storedIngredientId in request.StoredIngredientIds)
                {
                    var existingStoredIngredient = await _storedIngredientReporitory.Get(storedIngredientId);
                    if (existingStoredIngredient == null)
                    {
                        continue;
                    }

                    _storedIngredientReporitory.Delete(existingStoredIngredient);
                }

                await _storedIngredientReporitory.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during deleting users's stored ingredients");
                return false;
            }
        }
    }
}
