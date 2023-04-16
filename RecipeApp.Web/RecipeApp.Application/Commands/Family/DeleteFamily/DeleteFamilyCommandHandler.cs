using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.Family.DeleteFamilyService;

namespace RecipeApp.Application.Commands.Family.DeleteFamily
{
    public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand, bool>
    {
        private readonly IDeleteFamilyService _deleteFamilyService;
        private readonly ILogger _logger;

        public DeleteFamilyCommandHandler(
            IDeleteFamilyService deleteFamilyService,
            ILoggerFactory loggerFactory)
        {
            _deleteFamilyService = deleteFamilyService;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteFamilyCommandHandler));
        }

        public async Task<bool> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete family request");
            ArgumentNullException.ThrowIfNull(request);

            return await _deleteFamilyService.DeleteAsync(request.UserId, request.FamilyId);
        }
    }
}
