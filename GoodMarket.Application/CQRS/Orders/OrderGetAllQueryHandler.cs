using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class OrderGetAllQueryHandler : BaseGetAllQueryHandler<Order>
    {
        public OrderGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
