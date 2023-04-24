using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.MealPlanN.GetMealPlan
{
    public class GetMealPlanQueryHandler : IRequestHandler<GetMealPlanQuery, GetMealPlansDto>
    {
        private readonly IMealPlanQueryBuilder _mealPlanQueryBuilder;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetMealPlanQueryHandler(
            IMealPlanQueryBuilder mealPlanQueryBuilder,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _mealPlanQueryBuilder = mealPlanQueryBuilder;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetMealPlanQueryHandler));
        }

        public async Task<GetMealPlansDto> Handle(GetMealPlanQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get recipes request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<MealPlan> mealPlans = _mealPlanQueryBuilder
                .SetBaseMealPlanInfo()
                .SetId(request.MealPlansFiltering.MealPlanId)
                .SetFamilyId(request.MealPlansFiltering.FamilyId)
                .SetAppUserId(request.UserId)
                .Build();

            IEnumerable<GetMealPlanDto> mealPlanDtos = _mapper.Map<IEnumerable<GetMealPlanDto>>(mealPlans);
            return new ()
            {
                MealPlans = mealPlanDtos,
                ResultsAmount = mealPlanDtos.Count()
            };
        }
    }
}
