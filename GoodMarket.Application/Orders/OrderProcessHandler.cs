using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GoodMarket.Application.Orders
{
    public class OrderProcessRequest : IRequest<OrderProcessResponse>
    {

    }

    public class OrderProcessResponse
    {

    }
    
    /// <summary>
    /// Обработка состояния заказа
    /// </summary>
    public class OrderProcessHandler : IRequestHandler<OrderProcessRequest, OrderProcessResponse>
    {
        public async Task<OrderProcessResponse> Handle(OrderProcessRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
