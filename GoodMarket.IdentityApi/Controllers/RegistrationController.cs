using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using GoodMarket.IdentityApi;
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
        [ProducesResponseType(typeof(RegistrationResponse), 200)]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}