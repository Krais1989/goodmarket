using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodMarket.OrderProcessor.Orders;
using GoodMarket.YandexKassa;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GoodMarket.OrderProcessor.Controllers
{
    /// <summary>
    /// Контроллер приёма уведомлений от платежных систем
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderProcessController> _logger;

        public OrderProcessController(IMediator mediator, ILogger<OrderProcessController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Метод для яндекса
        /// </summary>
        [HttpPost("yandex")]
        public async Task<IActionResult> YandexOrderProcess([FromBody] YandexOrderProcessRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("ping")]
        [AllowAnonymous]
        public IActionResult Ping()
        {
            _logger.LogWarning($"Ping Test!");
            return Ok("Pong");
        }

        [HttpGet("exception")]
        [AllowAnonymous]
        public IActionResult Exception()
        {
            throw new Exception("Test Exception!");
        }

        [HttpGet("enqueue")]
        [AllowAnonymous]
        public IActionResult Enqueue()
        {
            var factory = new ConnectionFactory() {
                HostName = "localhost",
                Port = 5672,
                UserName = "gm_order_producer",
                Password = "qweqwe"
            };

            using (var con = factory.CreateConnection())
            {
                using (var channel = con.CreateModel())
                {
                    channel.QueueDeclare(queue: "order", durable: true, exclusive: false, autoDelete: false);
                    var body = Encoding.UTF8.GetBytes("Order process message!");
                    channel.BasicPublish(exchange: "order", routingKey: "", basicProperties: null, body: body);
                }
            }

            return Ok();
        }

        [HttpGet("dequeue")]
        [AllowAnonymous]
        public IActionResult Dequeue()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "gm_order_producer",
                Password = "qweqwe"
            };
            
            using (var con = factory.CreateConnection())
            {
                using (var channel = con.CreateModel())
                {
                    channel.BasicQos(0, 1, false);
                    channel.BasicConsume("order", false, new OrderMessageReceiver(_logger, channel));

                    //var consumer = new EventingBasicConsumer(channel);
                    //consumer.Received += Consumer_Received;
                    //channel.BasicConsume(queue: "order", autoAck: true, consumer: consumer);
                    //consumer.Received -= Consumer_Received;
                }
            }

            return Ok();
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var msg = Encoding.UTF8.GetString(e.Body);
            _logger.LogWarning($"Message: {msg}");
        }
    }
}
