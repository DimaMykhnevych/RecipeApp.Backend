using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.MealPlanRepository;

namespace RecipeApp.Application.Commands.MealPlanN.AddMealPlan
{
    public class AddMealPlanCommandHandler : IRequestHandler<AddMealPlanCommand, bool>
    {
        private readonly IMealPlanRepository _mealPlanRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddMealPlanCommandHandler(
            IMealPlanRepository mealPlanRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _mealPlanRepository = mealPlanRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(AddMealPlanCommandHandler));
        }

        public async Task<bool> Handle(AddMealPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add meal plan request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                MealPlan mealPlan = _mapper.Map<MealPlan>(request.MealPlan);
                mealPlan.AppUserId = request.UserId;
                mealPlan.MealPlanDate = DateTime.Now;

                await _mealPlanRepository.Insert(mealPlan);
                await _mealPlanRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during adding meal plan");
                return false;
            }
        }
    }
}
