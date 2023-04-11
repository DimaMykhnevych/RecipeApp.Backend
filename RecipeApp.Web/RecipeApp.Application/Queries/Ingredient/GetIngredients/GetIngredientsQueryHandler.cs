using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Repositories.IngredientRepository;

namespace RecipeApp.Application.Queries.Ingredient.GetIngredients
{
    public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, GetIngredientsDto>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetIngredientsQueryHandler(IIngredientRepository ingredientRepository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetIngredientsQueryHandler));
        }

        public async Task<GetIngredientsDto> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<Domain.Entities.Ingredient> ingredients = await _ingredientRepository.GetIngredients(request.IngredientName);
            return new GetIngredientsDto
            {
                Ingredients = _mapper.Map<IEnumerable<IngredientDto>>(ingredients),
                ResultsAmount = ingredients.Count()
            };
        }
    }
}
