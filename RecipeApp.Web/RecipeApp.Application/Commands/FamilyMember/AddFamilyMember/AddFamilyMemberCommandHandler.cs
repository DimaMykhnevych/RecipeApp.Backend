using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.FamilyMemberN.AddFamilyMemberService;

namespace RecipeApp.Application.Commands.FamilyMemberN.AddFamilyMember
{
    public class AddFamilyMemberCommandHandler : IRequestHandler<AddFamilyMemberCommand, bool>
    {
        private readonly IAddFamilyMemberService _addFamilyMemberService;
        private readonly ILogger _logger;

        public AddFamilyMemberCommandHandler(
            IAddFamilyMemberService addFamilyMemberService,
            ILoggerFactory loggerFactory)
        {
            _addFamilyMemberService = addFamilyMemberService;
            _logger = loggerFactory?.CreateLogger(nameof(AddFamilyMemberCommandHandler));
        }

        public async Task<bool> Handle(AddFamilyMemberCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add family member request");
            ArgumentNullException.ThrowIfNull(request);

            Domain.Entities.FamilyMember familyMemberToAdd = new()
            {
                FamilyId = request.FamilyMember.FamilyId,
                Info = request.FamilyMember.Info
            };

            if (request.FamilyMember.ExternalUserId.HasValue)
            {
                familyMemberToAdd.ExternalUserId = request.FamilyMember.ExternalUserId.Value;
            }
            else
            {
                familyMemberToAdd.ExternalUser = new()
                {
                    Name = request.FamilyMember.Name,
                    UserName = request.FamilyMember.UserName,
                    DOB = request.FamilyMember.DOB
                };
            }

            return await _addFamilyMemberService.AddFamilyMemberAsync(request.UserId, familyMemberToAdd);
        }
    }
}
