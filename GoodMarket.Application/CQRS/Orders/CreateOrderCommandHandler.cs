using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.CQRS
{
    public class CreateOrderRequest : IRequest<Order>
    {
        public Order Order;
        public CreateOrderRequest() { }
        public CreateOrderRequest(Order order) { Order = order; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, Order>
    {
        private GoodMarketDb _db;
        public CreateOrderCommandHandler(GoodMarketDb db)
        {
            _db = db;
        }

        public async Task<Order> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = request.Order;
            order.PendingDate = DateTime.Now;
            order.StatusDate = DateTime.Now;

            var result = await _db.AddAsync(order, cancellationToken);

            order.State = EOrderState.Pending;

            return await Task.FromResult(result.Entity);
        }
    }
}
