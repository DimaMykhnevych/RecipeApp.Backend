using MediatR;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.AddForbiddenNutrient
{
    public class AddForbiddenNutrientCommand : IRequest<bool>
    {
        public double? RequiredPercentageOfDailyNeeds { get; set; }
        public int NutrientId { get; set; }
        public int ExternalUserId { get; set; }
    }
}
