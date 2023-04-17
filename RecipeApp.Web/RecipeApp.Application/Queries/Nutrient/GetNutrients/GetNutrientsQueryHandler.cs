using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.NutrientN.GetNutrients
{
    public class GetNutrientsQueryHandler : IRequestHandler<GetNutrientsQuery, GetNutrientsDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetNutrientsQueryHandler(
            IRecipeAppDbContext context,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetNutrientsQueryHandler));
        }

        public async Task<GetNutrientsDto> Handle(GetNutrientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get nutrients request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<Nutrient> nutrients = await _context.Nutrients.ToListAsync(cancellationToken);
            IEnumerable<NutrientDto> nutrientDtos = _mapper.Map<IEnumerable<NutrientDto>>(nutrients);
            return new GetNutrientsDto
            {
                Nutrients = nutrientDtos,
                ResultsAmount = nutrientDtos.Count()
            };
        }
    }
}
