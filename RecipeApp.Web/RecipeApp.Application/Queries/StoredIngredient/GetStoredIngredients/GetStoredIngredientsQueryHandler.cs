using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;

namespace RecipeApp.Application.Queries.StoredIngredient.GetStoredIngredients
{
    public class GetStoredIngredientsQueryHandler : IRequestHandler<GetStoredIngredientsQuery, GetStoredIngredientsDto>
    {
        private readonly IStoredIngredientRepository _storedIngredientReporitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetStoredIngredientsQueryHandler(IStoredIngredientRepository storedIngredientReporitory, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _storedIngredientReporitory = storedIngredientReporitory;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetStoredIngredientsQueryHandler));
        }

        public async Task<GetStoredIngredientsDto> Handle(GetStoredIngredientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            var storedIngredients = await _storedIngredientReporitory.GetUserStoredIngredientsWithIngredientsInfo(request.UserId);
            return new GetStoredIngredientsDto
            {
                StoredIngredients = _mapper.Map<IEnumerable<StoredIngredientDto>>(storedIngredients),
                ResultsAmount = storedIngredients.Count()
            };
        }
    }
}
