using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Products
{
    public class ProductGetQueryHandler : BaseGetQueryHandler<Product>
    {
        public ProductGetQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
