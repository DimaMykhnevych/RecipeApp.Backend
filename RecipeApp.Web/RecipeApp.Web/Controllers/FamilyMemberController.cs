using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RecipeApp.Application.Commands.FamilyMember.DeleteFamilyMember;
using RecipeApp.Application.Commands.FamilyMemberN.AddFamilyMember;
using RecipeApp.Application.Commands.FamilyMemberN.UpdateFamilyMember;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FamilyMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FamilyMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves a user's family member", Description = "Set 'ExternalUserId' to null if adding new member and set all properties, " +
            "otherwise set 'ExternalUserId' to real external user id and leave all properties except 'Info' empty")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during saving users's family member")]
        public async Task<IActionResult> AddFamily([FromBody] AddFamilyMemberDto addFamilyMemberDto)
        {
            AddFamilyMemberCommand addFamilyMemberCommand = new()
            {
                FamilyMember = addFamilyMemberDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            try
            {
                bool result = await _mediator.Send(addFamilyMemberCommand);
                return result ? Ok(result) : BadRequest();
            }
            catch (UsernameAlreadyTakenException)
            {
                return Conflict(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Updates a user's family member")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during updating users's family member")]
        public async Task<IActionResult> UpdateFamily([FromBody] UpdateFamilyMemberDto updateFamilyMemberDto)
        {
            UpdateFamilyMemberCommand updateFamilyMemberCommand = new()
            {
                FamilyMember = updateFamilyMemberDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(updateFamilyMemberCommand);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{familyMemberId}")]
        [SwaggerOperation(Summary = "Deletes a user's family member")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during deleting users's family member")]
        public async Task<IActionResult> DeleteFamily(int familyMemberId)
        {
            DeleteFamilyMemberCommand deleteFamilyMemberCommand = new()
            {
                FamilyMemberId = familyMemberId,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID))
            };

            bool result = await _mediator.Send(deleteFamilyMemberCommand);
            return result ? Ok(result) : BadRequest();
        }

        private static ModelStateDictionary AddModelStateError(string field, string error)
        {
            ModelStateDictionary modelState = new();
            modelState.TryAddModelError(field, error);
            return modelState;
        }
    }
}
