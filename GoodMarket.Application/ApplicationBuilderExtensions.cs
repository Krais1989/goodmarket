using GoodMarket.Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace GoodMarket.Application
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Обработка и логирование исключений
        /// </summary>
        public static IApplicationBuilder UseGMExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }

        /// <summary>
        /// Отслеживание времени исполнения запросов
        /// </summary>
        public static IApplicationBuilder UseGMExecutionTimeTracking(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExecutionTimeTrackingMiddleware>();
            return app;
        }
    }
}
