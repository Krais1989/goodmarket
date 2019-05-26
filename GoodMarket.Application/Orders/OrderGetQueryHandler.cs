using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderGetQueryHandler : BaseGetQueryHandler<Order>
    {
        public OrderGetQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
