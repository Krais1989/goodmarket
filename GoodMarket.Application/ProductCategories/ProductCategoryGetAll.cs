using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.ProductCategories
{
    public class ProductCategoryGetAll : BaseGetAllQueryHandler<Category>
    {
        public ProductCategoryGetAll(GoodMarketDbContext db) : base(db) { }
    }
}
