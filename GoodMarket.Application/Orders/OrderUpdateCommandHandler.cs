using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Orders
{
    public class OrderUpdateCommandHandler : BaseUpdateCommandHandler<Order>
    {
        public OrderUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
