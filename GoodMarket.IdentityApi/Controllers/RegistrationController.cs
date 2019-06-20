using System;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.IdentityApi.Controllers
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

        [HttpPost("Confirmation")]
        public async Task<IActionResult> ConfirmByEmail([FromBody]EmailConfirmationRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


    }
}