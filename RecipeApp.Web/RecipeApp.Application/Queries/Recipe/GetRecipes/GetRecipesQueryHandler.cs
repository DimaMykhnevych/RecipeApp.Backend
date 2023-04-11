using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;

namespace RecipeApp.Application.Queries.Recipe.GetRecipes
{
    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, GetRecipesDto>
    {
        private readonly IRecipeQueryBuilder _recipeQueryBuilder;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRecipesQueryHandler(IRecipeQueryBuilder recipeQueryBuilder, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _recipeQueryBuilder = recipeQueryBuilder;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetRecipesQueryHandler));
        }

        public async Task<GetRecipesDto> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get recipes request");
            ArgumentNullException.ThrowIfNull(request);

            IRecipeQueryBuilder recipeBaseQuery = _recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetId(request.RecipeId)
                .SetTitle(request.Title)
                .SetCalories(request.FromCalories, request.ToCalories)
                .SetCarbs(request.FromCarbs, request.ToCarbs)
                .SetFat(request.FromFat, request.ToFat)
                .SetProtein(request.FromProtein, request.ToProtein)
                .SetReadyInMinutes(request.FromReadyInMinutes, request.ToReadyInMinutes)
                .SetVegan(request.IsVegan)
                .SetHealthy(request.IsHealthy)
                .SetSeason(request.Season)
                .SetDishType(request.DishType);

            // TODO get user's stored ingredients
            if (request.UseCurrentlyStoredIngredients.HasValue && request.UseCurrentlyStoredIngredients.Value)
            {
                recipeBaseQuery.SetIncludeIngredients(Array.Empty<int>());
            }

            // TODO get user's forbidden ingredients (possibly for certain family members)
            if (request.ExcludeForbiddenIngredients.HasValue && request.ExcludeForbiddenIngredients.Value)
            {
                recipeBaseQuery.SetExcludeIngredients(Array.Empty<int>());
            }

            IEnumerable<Domain.Entities.Recipe> recipes = recipeBaseQuery.Build();
            var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return new GetRecipesDto
            {
                Recipes = recipeDtos,
                ResultsAmount = recipeDtos.Count()
            };
        }
    }
}
