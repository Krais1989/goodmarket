using MediatR;
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
        public static IServiceCollection AddGMMediatoR(this IServiceCollection service)
        {
            return service.AddMediatR(typeof(MediatRServiceExtensions).Assembly);
        }
    }
}
