using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Services.DbManagement.CreateBackup;

namespace RecipeApp.Application.Commands.DbManagement.CreateBackup
{
    public class CreateBackupCommandHandler : IRequestHandler<CreateBackupCommand, DbBackupDto>
    {
        private readonly ICreateBackupService _createBackupService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateBackupCommandHandler(ICreateBackupService createBackupService, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _createBackupService = createBackupService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(CreateBackupCommandHandler));
        }

        public async Task<DbBackupDto> Handle(CreateBackupCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get database backup request");
            ArgumentNullException.ThrowIfNull(request);

            DbBackup backupResult = await _createBackupService.BackupDatabaseAsync();
            return _mapper.Map<DbBackupDto>(backupResult);
        }
    }
}
