using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Orders
{
    public class OrderCreateCommandHandler : BaseCreateCommandHandler<Order>
    {
        public OrderCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
