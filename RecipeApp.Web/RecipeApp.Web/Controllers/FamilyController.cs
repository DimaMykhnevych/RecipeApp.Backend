using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.Family.AddFamily;
using RecipeApp.Application.Commands.Family.DeleteFamily;
using RecipeApp.Application.Commands.Family.UpdateFamily;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.Family.GetAppUserFamilies;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FamilyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FamilyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a list of user's families")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetFamiliesDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetAppUserFamilies()
        {
            GetFamiliesDto families = await _mediator.Send(new GetAppUserFamiliesQuery
            {
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            });

            return Ok(families);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves a user's family")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during saving users's family")]
        public async Task<IActionResult> AddFamily([FromBody] AddFamilyDto addFamilyDto)
        {
            AddFamilyCommand addFamilyCommand = new()
            {
                Family = addFamilyDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(addFamilyCommand);
            return result ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Updates a user's family")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during updating users's family")]
        public async Task<IActionResult> UpdateFamily([FromBody] UpdateFamilyDto updateFamilyDto)
        {
            UpdateFamilyCommand updateFamilyCommand = new()
            {
                Family = updateFamilyDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(updateFamilyCommand);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{familyId}")]
        [SwaggerOperation(Summary = "Deletes a user's family")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during deleting users's family")]
        public async Task<IActionResult> DeleteFamily(int familyId)
        {
            DeleteFamilyCommand deleteFamilyCommand = new()
            {
                FamilyId = familyId,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(deleteFamilyCommand);
            return result ? Ok(result) : BadRequest();
        }
    }
}
