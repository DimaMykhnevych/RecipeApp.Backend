using MediatR;

namespace RecipeApp.Application.Commands.DbManagement.RestoreDb
{
    public class RestoreDbCommand : IRequest<bool>
    {
        public Stream RestoreFileStream { get; set; }
    }
}
