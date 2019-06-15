using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.Application.Middlewares
{
    /// <summary>
    /// Трекер времени исполнения запроса
    /// </summary>
    public class ExecutionTimeTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExecutionTimeTrackingMiddleware> _logger;

        public ExecutionTimeTrackingMiddleware(RequestDelegate next, ILogger<ExecutionTimeTrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            
            if (stopwatch.ElapsedMilliseconds < 300)
                _logger.LogInformation($"Execution time: {stopwatch.ElapsedMilliseconds}ms");
            else if (stopwatch.ElapsedMilliseconds < 2000)
                _logger.LogWarning($"Execution time: {stopwatch.ElapsedMilliseconds}ms");
            else
                _logger.LogError($"Execution time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
