using MediatR;

namespace RecipeApp.Application.Commands.PayOrder
{
    public class PayOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
