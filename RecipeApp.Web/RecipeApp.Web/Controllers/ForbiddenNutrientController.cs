using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.ForbiddenNutrientN.AddForbiddenNutrient;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.ForbiddenNutrientN.GetForbiddenNutrients;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ForbiddenNutrientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForbiddenNutrientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{externalUserId}")]
        [SwaggerOperation(Summary = "Gets a list of user's forbidden nutrients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetForbiddenNutrientsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> Get(int externalUserId)
        {
            GetForbiddenNutrientsDto forbiddenNutrients = await _mediator.Send(new GetForbiddenNutrientsQuery
            {
                ExternalUserId = externalUserId
            });

            return Ok(forbiddenNutrients);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves a user's forbidden nutrient")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during saving forbidden nutrient")]
        public async Task<IActionResult> AddForbiddenNutrient([FromBody] AddForbiddenNutrientCommand addForbiddenNutrientCommand)
        {
            bool result = await _mediator.Send(addForbiddenNutrientCommand);
            return result ? Ok(result) : BadRequest();
        }
    }
}
