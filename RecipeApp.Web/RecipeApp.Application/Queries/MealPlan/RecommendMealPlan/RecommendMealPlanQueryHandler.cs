using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService;

namespace RecipeApp.Application.Queries.MealPlanN.RecommendMealPlan
{
    public class RecommendMealPlanQueryHandler : IRequestHandler<RecommendMealPlanQuery, GetRecommendedMealPlanDto>
    {
        private readonly IMealPlanRecommendationService _mealPlanRecommendationService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RecommendMealPlanQueryHandler(
            IMealPlanRecommendationService mealPlanRecommendationService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _mealPlanRecommendationService = mealPlanRecommendationService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(RecommendMealPlanQueryHandler));
        }

        public async Task<GetRecommendedMealPlanDto> Handle(RecommendMealPlanQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling recommend meal plan request");
            ArgumentNullException.ThrowIfNull(request);

            Domain.Entities.MealPlan mealPlan = 
                await _mealPlanRecommendationService.GetRecommendedMealPlan(new ()
                {
                    AppUserId = request.AppUserId,
                    ExternalUserId = request.ExternalUserId,
                    AcceptableMatchIngredientsPercentage = request.MealPlanRecommendationParameters.AcceptableMatchIngredientsPercentage,
                    ConsiderIngredientsAmount = request.MealPlanRecommendationParameters.ConsiderIngredientsAmount
                });

            return _mapper.Map<GetRecommendedMealPlanDto>(mealPlan);
        }
    }
}
