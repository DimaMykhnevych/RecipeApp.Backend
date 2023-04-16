using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.FamilyMemberN.DeleteFamilyMemberService;

namespace RecipeApp.Application.Commands.FamilyMember.DeleteFamilyMember
{
    public class DeleteFamilyMemberCommandHandler : IRequestHandler<DeleteFamilyMemberCommand, bool>
    {
        private readonly IDeleteFamilyMemberService _deleteFamilyMemberService;
        private readonly ILogger _logger;

        public DeleteFamilyMemberCommandHandler(
            IDeleteFamilyMemberService deleteFamilyMemberService,
            ILoggerFactory loggerFactory)
        {
            _deleteFamilyMemberService = deleteFamilyMemberService;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteFamilyMemberCommandHandler));
        }

        public async Task<bool> Handle(DeleteFamilyMemberCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling delete family member request");
            ArgumentNullException.ThrowIfNull(request);

            return await _deleteFamilyMemberService.DeleteAsync(request.UserId, request.FamilyMemberId);
        }
    }
}
