using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Orders
{
    public class OrderGetQueryHandler : BaseGetQueryHandler<Order>
    {
        public OrderGetQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
