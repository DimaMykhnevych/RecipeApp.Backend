using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.DbManagement.CreateBackup
{
    public class CreateBackupCommand : IRequest<DbBackupDto>
    {
    }
}
