using GoodMarket.Application.MediatRs;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GoodMarket.Application
{
    public static class MediatRServiceExtensions
    {
        /// <summary>
        /// Включить MediatoR для GoodMarket
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddGMMediatoR(this IServiceCollection service, params Assembly[] assemblies)
        {
            return (assemblies.Length == 0)
                ? service.AddMediatR(typeof(MediatRServiceExtensions).Assembly)
                : service.AddMediatR(assemblies);
        }
    }
}
