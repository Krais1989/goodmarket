using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderGetAllQueryHandler : BaseGetAllQueryHandler<Order>
    {
        public OrderGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
