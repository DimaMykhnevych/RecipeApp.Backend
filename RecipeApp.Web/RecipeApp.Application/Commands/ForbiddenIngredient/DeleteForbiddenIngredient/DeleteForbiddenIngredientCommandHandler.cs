using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.DeleteForbiddenIngredient
{
    public class DeleteForbiddenIngredientCommandHandler : IRequestHandler<DeleteForbiddenIngredientCommand, bool>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IForbiddenIngredientRepository _forbiddenIngredientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteForbiddenIngredientCommandHandler(
            IRecipeAppDbContext context,
            IForbiddenIngredientRepository forbiddenIngredientRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _forbiddenIngredientRepository = forbiddenIngredientRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteForbiddenIngredientCommandHandler));
        }

        public async Task<bool> Handle(DeleteForbiddenIngredientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete forbidden ingredient request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                ForbiddenIngredient forbiddenIngredientToDelete = await _context.ForbiddenIngredients
                    .FirstOrDefaultAsync(fi => fi.AppUserId == request.AppUserId && fi.Id == request.ForbiddenIngredientId, cancellationToken: cancellationToken);
                if (forbiddenIngredientToDelete == null)
                {
                    return false;
                }

                _forbiddenIngredientRepository.Delete(forbiddenIngredientToDelete);
                await _forbiddenIngredientRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during deleting users's forbidden ingredient");
                return false;
            }
        }
    }
}
