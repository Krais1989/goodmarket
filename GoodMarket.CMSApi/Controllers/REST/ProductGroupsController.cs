using System.Threading.Tasks;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.AdminApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductCategorysController : BaseRestController<Category>
    {
        public ProductCategorysController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
