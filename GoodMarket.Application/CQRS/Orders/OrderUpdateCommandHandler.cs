using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class OrderUpdateCommandHandler : BaseUpdateCommandHandler<Order>
    {
        public OrderUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
