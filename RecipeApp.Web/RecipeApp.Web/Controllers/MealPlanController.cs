using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.MealPlanN.AddMealPlan;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.MealPlanN.GetMealPlan;
using RecipeApp.Application.Queries.MealPlanN.RecommendMealPlan;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealPlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MealPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a filtered list of meal plans", Description = "All parameters should be passed within the URI as a query parameters")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRecipesDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetMealPlans([FromQuery] MealPlansFilteringDto mealPlansFilteringDto)
        {
            GetMealPlanQuery mealPlanQuery = new ()
            {
                MealPlansFiltering = mealPlansFilteringDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID)),
            };

            GetMealPlansDto mealPlans = await _mediator.Send(mealPlanQuery);
            return Ok(mealPlans);
        }

        [HttpGet("recommendation/{externalUserId}")]
        [SwaggerOperation(Summary = "Gets a recommended meal plan")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRecommendedMealPlanDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetMealPlanRecommendation(int externalUserId)
        {
            GetRecommendedMealPlanDto mealPlan = await _mediator.Send(new RecommendMealPlanQuery 
            { 
                ExternalUserId = externalUserId,
                AppUserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            });
            return Ok(mealPlan);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adds a meal plane. FamilyId can be null")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during adding meal plan")]
        public async Task<IActionResult> AddMealPlan([FromBody] AddMealPlanDto addMealPlanDto)
        {
            AddMealPlanCommand mealPlanCommand = new() 
            {
                MealPlan = addMealPlanDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(mealPlanCommand);
            return result ? Ok(result) : BadRequest();
        }
    }
}
