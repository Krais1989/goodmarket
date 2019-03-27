using GoodMarket.Application.CQRS;
using GoodMarket.Domain;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Tests
{
    /// <summary>
    /// Настройка зависимостей для тестов
    /// Не должны работать с внешними источниками данных
    /// </summary>
    public static class TestDependencyMock
    {
        public static IServiceCollection Create()
        {
            return Configure(new ServiceCollection());
        }

        public static IServiceCollection Configure(IServiceCollection services)
        {
            /* Test factories */
            services.AddSingleton<TestEntityFactory<User>>();
            services.AddSingleton<TestEntityFactory<Product>>();

            services.AddMediatR();
            services.AddScoped(typeof(BaseGetQueryHandler<>));
            services.AddScoped(typeof(BaseGetAllQueryHandler<>));
            services.AddScoped(typeof(BaseCreateCommandHandler<>));
            services.AddScoped(typeof(BaseUpdateCommandHandler<>));
            services.AddScoped(typeof(BaseDeleteCommandHandler<>));
            return services;
        }
        
    }
}
