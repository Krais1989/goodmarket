using System;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;
using MediatR;

namespace GoodMarket.Application.Orders
{
    public class CreateOrderRequest : IRequest<Order>
    {
        public Order Order;
        public CreateOrderRequest() { }
        public CreateOrderRequest(Order order) { Order = order; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, Order>
    {
        private GoodMarketDbContext _db;
        public CreateOrderCommandHandler(GoodMarketDbContext db)
        {
            _db = db;
        }

        public async Task<Order> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = request.Order;
            order.CreateDate = DateTime.Now;
            order.StatusDate = DateTime.Now;
            order.Status = EOrderState.Pending;

            var result = await _db.AddAsync(order, cancellationToken);
            return await Task.FromResult(result.Entity);
        }
    }
}
