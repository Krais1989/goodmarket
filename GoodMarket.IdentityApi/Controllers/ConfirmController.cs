using GoodMarket.Application.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.IdentityApi.Controllers
{
    /// <summary>
    /// Контроллер подтверждения аккаунтов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegistrationController> _logger;

        public ConfirmController(IMediator mediator, ILogger<RegistrationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        
        [HttpPost("Email")]
        public async Task<IActionResult> ConfirmByEmail([FromBody]EmailConfirmationRequest request)
        {
            _logger.LogInformation($"Confirm email:\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("Phone")]
        public async Task<IActionResult> ConfirmByPhone([FromBody]PhoneConfirmationRequest request)
        {
            _logger.LogInformation($"Confirm phone:\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");
            await _mediator.Send(request);
            return Ok();
        }
    }
}
