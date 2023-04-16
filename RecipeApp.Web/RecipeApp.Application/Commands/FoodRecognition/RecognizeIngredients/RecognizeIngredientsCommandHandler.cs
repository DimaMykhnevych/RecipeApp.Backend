using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;

namespace RecipeApp.Application.Commands.FoodRecognition.RecognizeIngredients
{
    public class RecognizeIngredientsCommandHandler : IRequestHandler<RecognizeIngredientsCommand, RecognizedIngredientsDto>
    {
        private readonly IRecognizeIngredientsService _recognizeIngredientsService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RecognizeIngredientsCommandHandler(
            IRecognizeIngredientsService recognizeIngredientsService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _recognizeIngredientsService = recognizeIngredientsService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(RecognizeIngredientsCommandHandler));
        }

        public async Task<RecognizedIngredientsDto> Handle(RecognizeIngredientsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling recognize ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<Ingredient> predictions = await _recognizeIngredientsService.GetIngredientsPredictions(request.Image);
            IEnumerable<IngredientDto> predictionDtos = _mapper.Map<IEnumerable<IngredientDto>>(predictions);
            return new RecognizedIngredientsDto { Ingredients = predictionDtos };
        }
    }
}
