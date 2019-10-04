using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Products
{
    public class ProductCreateCommandHandler : BaseCreateCommandHandler<Product>
    {
        public ProductCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
