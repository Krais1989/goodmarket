using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Api.Authorization;
using GoodMarket.Application.Serialization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Register([FromBody]RegistrationRequest request)
        {
            var result = await _mediator.Send(request);
            Response.StatusCode = result.Success ? 200 : 400;
            Response.ContentType = "application/json";
            await Response.WriteAsync(SSerializer.Serialize(result));
        }
    }
}