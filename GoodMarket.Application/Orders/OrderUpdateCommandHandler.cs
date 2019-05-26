using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderUpdateCommandHandler : BaseUpdateCommandHandler<Order>
    {
        public OrderUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
