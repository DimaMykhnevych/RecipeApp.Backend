using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.ForbiddenIngredientN.AddForbiddenIngredient;
using RecipeApp.Application.Commands.ForbiddenIngredientN.DeleteForbiddenIngredient;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.ForbiddenIngredientN.GetForbiddenIngredients;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ForbiddenIngredientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForbiddenIngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a list of user's forbidden ingredients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetForbiddenIngredientsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> Get()
        {
            GetForbiddenIngredientsDto forbiddenNutrients = await _mediator.Send(new GetForbiddenIngredientsQuery
            {
                AppUserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            });

            return Ok(forbiddenNutrients);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves a user's forbidden ingredient")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during saving forbidden ingredient")]
        public async Task<IActionResult> AddForbiddenIngredient([FromBody] AddForbiddenIngredientDto addForbiddenIngredientDto)
        {
            bool result = await _mediator.Send(new AddForbiddenIngredientCommand 
            { 
                ForbiddenIngredient = addForbiddenIngredientDto,
                AppUserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            });
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{forbiddenIngredientId}")]
        [SwaggerOperation(Summary = "Deletes a users's forbidden ingredient")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during deleting users's forbidden ingredient")]
        public async Task<IActionResult> Delete(int forbiddenIngredientId)
        {
            DeleteForbiddenIngredientCommand deleteForbiddenIngredientCommand = new()
            {
                ForbiddenIngredientId = forbiddenIngredientId,
                AppUserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(deleteForbiddenIngredientCommand);
            return result ? Ok(result) : BadRequest();
        }
    }
}
