using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.ForbiddenIngredientN.GetForbiddenIngredients
{
    public class GetForbiddenIngredientsQueryHandler : IRequestHandler<GetForbiddenIngredientsQuery, GetForbiddenIngredientsDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetForbiddenIngredientsQueryHandler(
            IRecipeAppDbContext context,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetForbiddenIngredientsQueryHandler));
        }

        public async Task<GetForbiddenIngredientsDto> Handle(GetForbiddenIngredientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get forbidden ingredients request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<ForbiddenIngredient> forbiddenIngredients = await _context.ForbiddenIngredients
                .Include(fi => fi.Ingredient)
                .AsNoTracking()
                .Where(fn => fn.ExternalUserId == request.ExternalUserId)
                .ToListAsync(cancellationToken);
            IEnumerable<ForbiddenIngredientDto> forbiddenIngredientDtos = _mapper.Map<IEnumerable<ForbiddenIngredientDto>>(forbiddenIngredients);
            return new GetForbiddenIngredientsDto
            {
                ForbiddenIngredients = forbiddenIngredientDtos,
                ResultsAmount = forbiddenIngredientDtos.Count()
            };
        }
    }
}
