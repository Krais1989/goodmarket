using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderCreateCommandHandler : BaseCreateCommandHandler<Order>
    {
        public OrderCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
