using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.MediatRs
{
    /// <summary>
    /// Препроцессор MediatR запросов - логирование
    /// </summary>
    public class RequestLoggerPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILoggerFactory _logFactory;

        public RequestLoggerPreProcessor(ILoggerFactory logFactory)
        {
            _logFactory = logFactory;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var logger = _logFactory.CreateLogger<TRequest>();
            logger.LogInformation($"MediatR Begin Request: {typeof(TRequest).Name}");
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Постпроцессор MediatR запросов - логирование
    /// </summary>
    public class RequestLoggerPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILoggerFactory _logFactory;

        public RequestLoggerPostProcessor(ILoggerFactory logFactory)
        {
            _logFactory = logFactory;
        }
        
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var logger = _logFactory.CreateLogger<TRequest>();
            logger.LogInformation($"MediatR End Request: {typeof(TRequest).Name} - Response: {typeof(TResponse).Name}");
            return Task.CompletedTask;
        }
    }
}
