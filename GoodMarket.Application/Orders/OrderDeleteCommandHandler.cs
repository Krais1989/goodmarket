using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderDeleteCommandHandler : BaseDeleteCommandHandler<Order>
    {
        public OrderDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
