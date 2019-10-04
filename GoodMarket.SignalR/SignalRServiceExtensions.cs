using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GoodMarket.SignalR
{
    public static class SignalRServiceExtensions
    {
        public static IServiceCollection AddGMSignalRServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSignalR(opts => {
                opts.KeepAliveInterval = TimeSpan.FromSeconds(10);
                opts.HandshakeTimeout = TimeSpan.FromSeconds(10);
                opts.EnableDetailedErrors = true;
                opts.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
            });
            return services;
        }
    }
}
