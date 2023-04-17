using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.ForbiddenNutrientN.GetForbiddenNutrients
{
    public class GetForbiddenNutrientsQueryHandler : IRequestHandler<GetForbiddenNutrientsQuery, GetForbiddenNutrientsDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetForbiddenNutrientsQueryHandler(
            IRecipeAppDbContext context,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetForbiddenNutrientsQueryHandler));
        }

        public async Task<GetForbiddenNutrientsDto> Handle(GetForbiddenNutrientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get forbidden nutrients request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<ForbiddenNutrient> forbiddenNutrients = await _context.ForbiddenNutrients
                .Include(dn => dn.Nutrient)
                .AsNoTracking()
                .Where(fn => fn.ExternalUserId == request.ExternalUserId)
                .ToListAsync(cancellationToken);
            IEnumerable<ForbiddenNutrientDto> forbiddenNutrientDtos = _mapper.Map<IEnumerable<ForbiddenNutrientDto>>(forbiddenNutrients);
            return new GetForbiddenNutrientsDto
            {
                ForbiddenNutrients = forbiddenNutrientDtos,
                ResultsAmount = forbiddenNutrientDtos.Count()
            };
        }
    }
}
