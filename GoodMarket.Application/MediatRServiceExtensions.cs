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
        public static IServiceCollection AddApplicationMediatR(this IServiceCollection service)
        {
            return service.AddMediatR(typeof(MediatRServiceExtensions).Assembly);
        }
    }
}
