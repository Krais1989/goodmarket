using GoodMarket.Domain.Entities.Products;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.AdminApi.Controllers.REST
{
    [Route("api/[controller]")]
    public class ProductsController : BaseRestController<Product>
    {
        public ProductsController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
