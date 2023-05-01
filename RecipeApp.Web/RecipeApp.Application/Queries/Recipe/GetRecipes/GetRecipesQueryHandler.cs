using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Services.RecipeN.IncludeIngredientsService;

namespace RecipeApp.Application.Queries.RecipeN.GetRecipes
{
    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, GetRecipesDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IRecipeQueryBuilder _recipeQueryBuilder;
        private readonly IIncludeIngredientsService _includeIngredientsService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRecipesQueryHandler(
            IRecipeAppDbContext context,
            IRecipeQueryBuilder recipeQueryBuilder,
            IIncludeIngredientsService includeIngredientsService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _recipeQueryBuilder = recipeQueryBuilder;
            _includeIngredientsService = includeIngredientsService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetRecipesQueryHandler));
        }

        public async Task<GetRecipesDto> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get recipes request");
            ArgumentNullException.ThrowIfNull(request);

            IRecipeQueryBuilder recipeBaseQuery = _recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetId(request.RecipesFiltering.RecipeId)
                .SetTitle(request.RecipesFiltering.Title)
                .SetCalories(request.RecipesFiltering.FromCalories, request.RecipesFiltering.ToCalories)
                .SetCarbs(request.RecipesFiltering.FromCarbs, request.RecipesFiltering.ToCarbs)
                .SetFat(request.RecipesFiltering.FromFat, request.RecipesFiltering.ToFat)
                .SetProtein(request.RecipesFiltering.FromProtein, request.RecipesFiltering.ToProtein)
                .SetReadyInMinutes(request.RecipesFiltering.FromReadyInMinutes, request.RecipesFiltering.ToReadyInMinutes)
                .SetVegan(request.RecipesFiltering.IsVegan)
                .SetHealthy(request.RecipesFiltering.IsHealthy)
                .SetSeason(request.RecipesFiltering.Season)
                .SetDishType(request.RecipesFiltering.DishType);

            if (request.RecipesFiltering.GetUserCreatedRecipesOnly != null 
                && request.RecipesFiltering.GetUserCreatedRecipesOnly.Value)
            {
                recipeBaseQuery.SetRecipeCreatorId(request.UserId);
            }

            if (request.RecipesFiltering.ExcludeForbiddenIngredients.HasValue && request.RecipesFiltering.ExcludeForbiddenIngredients.Value)
            {
                var appUserExternal = await _context.ExternalUsers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.AppUserId == request.UserId);
                int externalUserId = request.RecipesFiltering.ExternalUserId ?? appUserExternal.Id;
                var excludeIngredients = await _context.ForbiddenIngredients
                    .AsNoTracking()
                    .Where(fi => fi.ExternalUserId == externalUserId)
                    .ToListAsync();
                recipeBaseQuery.SetExcludeIngredients(excludeIngredients.Select(i => i.IngredientId));
            }

            IEnumerable<Recipe> recipes = recipeBaseQuery.Build();
            RecipesMatchingResult matchingResult = null;
            if (request.RecipesFiltering.UseCurrentlyStoredIngredients.HasValue && request.RecipesFiltering.UseCurrentlyStoredIngredients.Value)
            {
                SetStoredIngredients setIngredientsModel = new()
                {
                    UserId = request.UserId,
                    FilteredRecipes = recipes,
                    ConsiderIngredientsAmount = request.RecipesFiltering.ConsiderIngredientsAmount,
                    AcceptableMatchIngredientsPercentage = request.AcceptableMatchIngredientsPercentage
                };
                matchingResult = await _includeIngredientsService.SetIncludeIngredients(setIngredientsModel);
                recipes = matchingResult.FilteredRecipes;
            }

            var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            if (matchingResult != null && matchingResult.RecipesMatchingPercentage != null)
            {
                foreach (var recipe in recipeDtos)
                {
                    recipe.IngredientsMatchingPercentage = matchingResult.RecipesMatchingPercentage[recipe.Id];
                }
            }

            return new GetRecipesDto
            {
                Recipes = recipeDtos,
                ResultsAmount = recipeDtos.Count()
            };
        }
    }
}
