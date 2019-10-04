using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Orders
{
    public class OrderDeleteCommandHandler : BaseDeleteCommandHandler<Order>
    {
        public OrderDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
