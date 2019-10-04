using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;

namespace GoodMarket.Application.ProductCategories
{
    public class ProductCategoryCreate : BaseCreateCommandHandler<Category>
    {
        public ProductCategoryCreate(GoodMarketDbContext db) : base(db) { }
    }
}
