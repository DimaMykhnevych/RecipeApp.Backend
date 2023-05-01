using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.StoredIngredient.DeleteStoredIngredients;
using RecipeApp.Application.Commands.StoredIngredient.SaveStoredIngredients;
using RecipeApp.Application.Commands.StoredIngredient.UpdateStoredIngredients;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.StoredIngredient.GetStoredIngredients;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoredIngredientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoredIngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a list of users's stored ingredients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetStoredIngredientsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetUserStoredIngredients()
        {
            GetStoredIngredientsDto result = await _mediator.Send(new GetStoredIngredientsQuery 
            { 
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID)) 
            });

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves a list of users's stored ingredients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during saving users's stored ingredients")]
        public async Task<IActionResult> Save([FromBody] IEnumerable<AddStoredIngredientDto> storedIngredients)
        {
            SaveStoredIngredientsCommand saveStoredIngredientsCommand = new()
            {
                StoredIngredients = storedIngredients,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(saveStoredIngredientsCommand);
            return result ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Updates a list of users's stored ingredients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during updating users's stored ingredients")]
        public async Task<IActionResult> Update([FromBody] UpdateStoredIngredientsCommand updateStoredIngredientsCommand)
        {
            bool result = await _mediator.Send(updateStoredIngredientsCommand);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Deletes a list of users's stored ingredients")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during deleting users's stored ingredients")]
        public async Task<IActionResult> Delete([FromBody] DeleteStoredIngredientsCommand deleteStoredIngredientsCommand)
        {
            bool result = await _mediator.Send(deleteStoredIngredientsCommand);
            return result ? Ok(result) : BadRequest();
        }
    }
}
