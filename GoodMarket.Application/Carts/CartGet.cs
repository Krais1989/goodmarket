using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Carts
{
    public class CartGet : BaseGetQueryHandler<Cart>
    {
        public CartGet(GoodMarketDbContext db) : base(db) { }
    }
}
