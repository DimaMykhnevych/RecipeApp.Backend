using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.Recipe.GetRecipes;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a filtered list of recipes", Description = "All parameters should be passed within the URI as a query parameters")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRecipesDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> Get([FromQuery] GetRecipesQuery getRecipesQuery)
        {
            GetRecipesDto recipes = await _mediator.Send(getRecipesQuery);
            return Ok(recipes);
        }
    }
}
