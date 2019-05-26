using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryDelete : BaseDeleteCommandHandler<Category>
    {
        public ProductCategoryDelete(GoodMarketDb db) : base(db) { }
    }
}
