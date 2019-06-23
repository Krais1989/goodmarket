using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CartDelete : BaseDeleteCommandHandler<Cart>
    {
        public CartDelete(GoodMarketDbContext db) : base(db) { }
    }
}
