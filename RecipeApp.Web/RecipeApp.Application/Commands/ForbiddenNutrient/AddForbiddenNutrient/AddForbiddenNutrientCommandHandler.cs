using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.AddForbiddenNutrient
{
    public class AddForbiddenNutrientCommandHandler : IRequestHandler<AddForbiddenNutrientCommand, bool>
    {
        private readonly IForbiddenNutrientRepository _forbiddenNutrientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddForbiddenNutrientCommandHandler(
            IForbiddenNutrientRepository forbiddenNutrientRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _forbiddenNutrientRepository = forbiddenNutrientRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(AddForbiddenNutrientCommandHandler));
        }

        public async Task<bool> Handle(AddForbiddenNutrientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add forbidden nutrient request");
            ArgumentNullException.ThrowIfNull(request);

            ForbiddenNutrient forbiddenNutrient = _mapper.Map<ForbiddenNutrient>(request);
            if (forbiddenNutrient.RequiredPercentageOfDailyNeeds == null
                || forbiddenNutrient.RequiredPercentageOfDailyNeeds < 0)
            {
                forbiddenNutrient.RequiredPercentageOfDailyNeeds = 0;
            }

            try
            {
                await _forbiddenNutrientRepository.Insert(forbiddenNutrient);
                await _forbiddenNutrientRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during saving users's forbidden nutrient" +
                    " (NutrientId: {NutrientId}, ExternalUserId: {ExternalUserId})", request.NutrientId, request.ExternalUserId);
                return false;
            }
        }
    }
}
