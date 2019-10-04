using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.ProductCategories
{
    public class ProductCategoryGet : BaseGetQueryHandler<Category>
    {
        public ProductCategoryGet(GoodMarketDbContext db) : base(db) { }
    }
}
