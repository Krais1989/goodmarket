using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.ProductCategories
{
    public class ProductCategoryDelete : BaseDeleteCommandHandler<Category>
    {
        public ProductCategoryDelete(GoodMarketDbContext db) : base(db) { }
    }
}
