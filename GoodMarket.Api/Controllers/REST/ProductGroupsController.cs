using System.Threading.Tasks;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductCategorysController : BaseRestController<Category>
    {
        public ProductCategorysController(GoodMarketDb context, IMediator mediator) : base(context, mediator)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] Category value)
        {
            return await base.Post(value);
        }
    }
}
