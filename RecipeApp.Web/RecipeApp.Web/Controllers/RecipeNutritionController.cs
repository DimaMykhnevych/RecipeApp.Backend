using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.RecipeN.AddRecipeNutrition;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeNutritionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeNutritionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-recipe-nutrition")]
        [SwaggerOperation(Summary = "Adds recipe nutrition. Can only be performed by admin")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "User is not administrator")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddRecipeNutrition([FromBody] AddRecipeNutritionCommand addRecipeNutritionCommand)
        {
            var result = await _mediator.Send(addRecipeNutritionCommand);
            return Ok(result);
        }
    }
}
