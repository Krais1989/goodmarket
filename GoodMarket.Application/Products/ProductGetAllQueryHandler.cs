using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Products
{
    public class ProductGetAllQueryHandler : BaseGetAllQueryHandler<Product>
    {
        public ProductGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
