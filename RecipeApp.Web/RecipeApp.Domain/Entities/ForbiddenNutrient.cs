namespace RecipeApp.Domain.Entities
{
    public class ForbiddenNutrient
    {
        public int Id { get; set; }
        public double? RequiredPercentageOfDailyNeeds { get; set; }
        public int NutrientId { get; set; }
        public int ExternalUserId { get; set; }

        public Nutrient Nutrient { get; set; }
        public ExternalUser ExternalUser { get; set; }
    }
}
