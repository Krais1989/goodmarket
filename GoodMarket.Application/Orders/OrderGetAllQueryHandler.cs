using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Orders
{
    public class OrderGetAllQueryHandler : BaseGetAllQueryHandler<Order>
    {
        public OrderGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
