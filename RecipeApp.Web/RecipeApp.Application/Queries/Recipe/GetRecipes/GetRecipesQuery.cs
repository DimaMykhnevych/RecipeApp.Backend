using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.RecipeN.GetRecipes
{
    public class GetRecipesQuery : IRequest<GetRecipesDto>
    {
        public int UserId { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
        public RecipesFilteringDto RecipesFiltering { get; set; }
    }
}
