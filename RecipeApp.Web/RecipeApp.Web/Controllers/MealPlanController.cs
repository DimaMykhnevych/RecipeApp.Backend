using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.DTOs;
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
    }
}
