using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class AddIngestionDto
    {
        public int Order { get; set; }
        public DishType DishType { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
