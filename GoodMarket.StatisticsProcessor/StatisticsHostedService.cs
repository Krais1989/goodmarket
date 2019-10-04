using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GoodMarket.StatisticsProcessor
{
    /// <summary>
    /// Сервис сбора статистики
    /// </summary>
    public class StatisticsHostedService : IHostedService
    {
        private readonly ILogger<StatisticsHostedService> _logger;

        public StatisticsHostedService(ILogger<StatisticsHostedService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop");
        }
    }
}