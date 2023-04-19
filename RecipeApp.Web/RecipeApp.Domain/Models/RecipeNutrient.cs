using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Models
{
    public class RecipeNutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public double Amount { get; set; }
        public double PercentOfDailyNeeds { get; set; }

        public RecipeNutrient ShallowCopy()
        {
            return (RecipeNutrient)MemberwiseClone();
        }
    }
}
