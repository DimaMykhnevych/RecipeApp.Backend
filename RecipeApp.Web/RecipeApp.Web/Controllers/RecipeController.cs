﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.Recipe.GetRecipes;
using RecipeApp.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;

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
        [SwaggerOperation(Summary = "Gets a filtered list of recipes", Description =
            "All parameters should be passed within the URI as a query parameters. " +
            "AcceptableMatchIngredientsPercentage parameter should be passed within headers (default value is 80%)")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRecipesDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> Get([FromQuery] RecipesFilteringDto recipesFilteringDto, [FromHeader] double? acceptableMatchIngredientsPercentage)
        {
            GetRecipesQuery getRecipesQuery = new()
            {
                RecipesFiltering = recipesFilteringDto,
                UserId = int.Parse(User.FindFirstValue(AuthorizationConstants.ID)),
                AcceptableMatchIngredientsPercentage = acceptableMatchIngredientsPercentage
            };

            GetRecipesDto recipes = await _mediator.Send(getRecipesQuery);
            return Ok(recipes);
        }
    }
}