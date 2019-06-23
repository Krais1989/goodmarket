using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GoodMarket.Application.Mappers
{
    public static class GMMappingExtensions
    {
        /// <summary>
        /// Автомаппинги GoodMarket
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGMAutoMapping(this IServiceCollection services)
        {
            return services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
