﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.FoodRecognition.RecognizeIngredients;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.Ingredient.GetIngredients;
using RecipeApp.Domain.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets a filtered list of ingredients", Description = "All parameters should be passed within the URI as a query parameters")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetIngredientsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        public async Task<IActionResult> GetIngredients([FromQuery] GetIngredientsQuery getIngredientsQuery)
        {
            GetIngredientsDto ingredients = await _mediator.Send(getIngredientsQuery);
            return Ok(ingredients);
        }

        [HttpPost("recognize-ingredients")]
        [SwaggerOperation(Summary = "Recognized ingredients by provided photo")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RecognizedIngredientsDto))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, Description = "Photo was not provided")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Error during communicating with RoboflowAPI")]
        public async Task<IActionResult> RecognizeIngredients(IFormFile file)
        {
            if (file == null && !HttpContext.Request.Form.Files.Any())
            {
                return UnprocessableEntity();
            }

            file ??= HttpContext.Request.Form.Files[0];

            using MemoryStream ms = new();
            file.CopyTo(ms);

            try
            {
                RecognizedIngredientsDto restoreResult = await _mediator.Send(new RecognizeIngredientsCommand { Image = ms });
                return Ok(restoreResult);
            }
            catch(RoboflowApiException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
