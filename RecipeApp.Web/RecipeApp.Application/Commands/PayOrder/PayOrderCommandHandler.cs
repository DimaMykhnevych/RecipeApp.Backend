using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Application.Commands.PayOrder
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, bool>
    {
        public PayOrderCommandHandler()
        {

        }

        public async Task<bool> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
