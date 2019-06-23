using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.AdminApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseRestController<User>
    {
        public UsersController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
