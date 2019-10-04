using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Carts
{
    public class CartDelete : BaseDeleteCommandHandler<Cart>
    {
        public CartDelete(GoodMarketDbContext db) : base(db) { }
    }
}
