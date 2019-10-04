using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.AdminApi.Controllers.REST
{
    [Route("api/[controller]")]
    public class UsersController : BaseRestController<User>
    {
        public UsersController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
