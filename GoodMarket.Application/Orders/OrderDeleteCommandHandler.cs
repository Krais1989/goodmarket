using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderDeleteCommandHandler : BaseDeleteCommandHandler<Order>
    {
        public OrderDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
