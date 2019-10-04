using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Products
{
    public class ProductUpdateCommandHandler : BaseUpdateCommandHandler<Product>
    {
        public ProductUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
