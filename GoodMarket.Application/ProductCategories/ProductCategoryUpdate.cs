using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.ProductCategories
{
    public class ProductCategoryUpdate : BaseUpdateCommandHandler<Category>
    {
        public ProductCategoryUpdate(GoodMarketDbContext db) : base(db) { }
    }
}
