using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Application.Orders;
using MediatR;

namespace GoodMarket.OrderProcessor.YandexKassa
{
    public enum YandexOrderStatus
    {
        Success, Pending, WaitForCapture, Cancel
    }

    public class YandexOrderProcessRequest : IRequest<YandexOrderProcessResponse>
    {

    }

    public class YandexOrderProcessResponse
    {

    }

    /// <summary>
    /// Обработчик 
    /// </summary>
    public class YandexOrderHandler : IRequestHandler<YandexOrderProcessRequest, YandexOrderProcessResponse>
    {
        private readonly IMediator _mediator;

        public YandexOrderHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<YandexOrderProcessResponse> Handle(YandexOrderProcessRequest request, CancellationToken cancellationToken)
        {
            // Проверка запроса яндекса

            // Запрос изменения заказа

            // Изменение заказа
            var result = await _mediator.Send(new OrderProcessRequest(), cancellationToken);

            // Логирование

            // Результат
            return new YandexOrderProcessResponse()
            {
                
            };
        }
    }
}
