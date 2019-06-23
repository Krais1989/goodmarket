using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductGetAllQueryHandler : BaseGetAllQueryHandler<Product>
    {
        public ProductGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
