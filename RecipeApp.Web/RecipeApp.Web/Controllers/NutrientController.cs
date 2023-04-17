using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.NutrientN.GetNutrients;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NutrientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NutrientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a list of nutrients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetNutrientsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetNutrients()
        {
            GetNutrientsDto nutrients = await _mediator.Send(new GetNutrientsQuery());
            return Ok(nutrients);
        }
    }
}
