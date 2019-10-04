using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Carts
{
    public class CartGetAll : BaseGetAllQueryHandler<Cart>
    {
        public CartGetAll(GoodMarketDbContext db) : base(db) { }
    }
}
