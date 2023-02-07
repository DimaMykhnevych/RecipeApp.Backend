﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.Auth.SignIn;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.User.GetUser;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [Route("current-user-info")]
        [SwaggerOperation(Summary = "Gets current logged in user info")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserAuthInfoDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "User was not found")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetUserInfo()
        {
            IEnumerable<UserAuthInfoDto> users = await _mediator.Send(new GetUserQuery { UserName = User.Identity.Name });

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users.First());
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        [SwaggerOperation(Summary = "Gets a Bearer token with basic user info in case of successful authorization",
            Description = "As a result returns the model with LoginErrorCode property.\n\nPossible LoginErrorCode values:\n\n" +
            "0 = Invalid userName or password\n\n" +
            "1 = Email confirmation required\n\n" +
            "100 = User was successfully authorized")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JWTTokenStatusResultDto))]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            JWTTokenStatusResultDto result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
