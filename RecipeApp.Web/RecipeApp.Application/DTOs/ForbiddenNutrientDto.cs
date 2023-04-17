using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class ForbiddenNutrientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public double? RequiredPercentageOfDailyNeeds { get; set; }
        public int NutrientId { get; set; }
        public int ExternalUserId { get; set; }
    }
}
