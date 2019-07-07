using System;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Registration;
using GoodMarket.RabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GoodMarket.IdentityApi.Controllers
{
    public class RegistrationRequestDto
    {
    }

    public class RegistrationResponseDto
    {

    }

    /// <summary>
    /// Контроллер регистрации аккаунтов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegistrationController> _logger;
        private readonly IBaseQueueProducer _queueProducer;

        public RegistrationController(
            IBaseQueueProducer queueProducer,
            IMediator mediator,
            ILogger<RegistrationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _queueProducer = queueProducer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegistrationResponse), 200)]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest request)
        {
            _logger.LogInformation($"Registration user:\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}