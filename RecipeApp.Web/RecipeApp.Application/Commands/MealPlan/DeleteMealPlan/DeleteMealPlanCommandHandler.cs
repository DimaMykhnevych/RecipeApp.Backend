using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.MealPlanRepository;

namespace RecipeApp.Application.Commands.MealPlanN.DeleteMealPlan
{
    public class DeleteMealPlanCommandHandler : IRequestHandler<DeleteMealPlanCommand, bool>
    {
        public readonly IMealPlanRepository _mealPlanRepository;
        private readonly ILogger _logger;

        public DeleteMealPlanCommandHandler(
            IMealPlanRepository mealPlanRepository,
            ILoggerFactory loggerFactory)
        {
            _mealPlanRepository = mealPlanRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteMealPlanCommandHandler));
        }

        public async Task<bool> Handle(DeleteMealPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete meal plan request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                MealPlan mealPlanToDelete = await _mealPlanRepository.Get(request.MealPlanId);
                if (mealPlanToDelete == null || mealPlanToDelete.AppUserId != request.AppUserId)
                {
                    return false;
                }

                _mealPlanRepository.Delete(mealPlanToDelete);
                await _mealPlanRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during deleting the meal plan");
                return false;
            }
        }
    }
}
