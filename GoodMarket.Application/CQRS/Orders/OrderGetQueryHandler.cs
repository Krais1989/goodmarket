using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class OrderGetQueryHandler : BaseGetQueryHandler<Order>
    {
        public OrderGetQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
