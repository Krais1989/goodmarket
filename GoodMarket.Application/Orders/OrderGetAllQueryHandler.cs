using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class OrderGetAllQueryHandler : BaseGetAllQueryHandler<Order>
    {
        public OrderGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
