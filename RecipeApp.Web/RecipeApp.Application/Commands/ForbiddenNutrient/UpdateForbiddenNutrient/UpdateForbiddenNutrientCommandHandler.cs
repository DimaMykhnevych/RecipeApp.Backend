using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Services.ForbiddenNutrientN.UpdateForbiddenNutrientService;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.UpdateForbiddenNutrient
{
    public class UpdateForbiddenNutrientCommandHandler : IRequestHandler<UpdateForbiddenNutrientCommand, bool>
    {
        private readonly IUpdateForbiddenNutrientService _updateForbiddenNutrientService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateForbiddenNutrientCommandHandler(
            IUpdateForbiddenNutrientService updateForbiddenNutrientService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _updateForbiddenNutrientService = updateForbiddenNutrientService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateForbiddenNutrientCommandHandler));
        }

        public async Task<bool> Handle(UpdateForbiddenNutrientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling update forbidden nutrient request");
            ArgumentNullException.ThrowIfNull(request);

            ForbiddenNutrient nutrientToUpdate = _mapper.Map<ForbiddenNutrient>(request.ForbiddenNutrient);
            return await _updateForbiddenNutrientService.UpdateForbiddenNutrientAsync(request.AppUserId, nutrientToUpdate);
        }
    }
}
