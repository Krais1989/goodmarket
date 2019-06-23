using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CartGetAll : BaseGetAllQueryHandler<Cart>
    {
        public CartGetAll(GoodMarketDbContext db) : base(db) { }
    }
}
