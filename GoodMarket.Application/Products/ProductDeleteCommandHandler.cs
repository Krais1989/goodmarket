using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Products
{
    public class ProductDeleteCommandHandler : BaseDeleteCommandHandler<Product>
    {
        public ProductDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
