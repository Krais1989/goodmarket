using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GoodMarket.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly AccountRegistrationQueueProducer _queueProducer;
        private readonly ILogger<QueueController> _logger;

        public QueueController(
            ILogger<QueueController> logger,
            AccountRegistrationQueueProducer queueProducer)
        {
            _queueProducer = queueProducer;
        }

        [HttpGet("[action]/{count:int}")]
        public async Task<IActionResult> Produce(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _queueProducer.Publish(new { Source = nameof(QueueController), Payload = new { Name = "Egor", Age = 29 } });
            }

            return Ok();
        }
    }
}