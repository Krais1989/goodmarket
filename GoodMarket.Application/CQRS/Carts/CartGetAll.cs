using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CartGetAll : BaseGetAllQueryHandler<Cart>
    {
        public CartGetAll(GoodMarketDb db) : base(db) { }
    }
}
