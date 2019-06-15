using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.Application.Middlewares
{
    /// <summary>
    /// Централизованная обработка исключений
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IHostingEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                string agent = context.Request.Headers["User-Agent"].ToString();
                string rem_ip = context.Connection.RemoteIpAddress.ToString();
                string rem_port = context.Connection.RemotePort.ToString();
                string loc_ip = context.Connection.LocalIpAddress.ToString();
                string loc_port = context.Connection.LocalPort.ToString();
                bool isAuthenticated = context.User.Identity.IsAuthenticated;
                string userName = isAuthenticated ? context.User.FindFirst(ClaimTypes.Name)?.Value : "[Anonymous]";

                var errLog = new StringBuilder();
                errLog.AppendLine($"IP: ({rem_ip}:{rem_port}) => ({loc_ip}:{loc_port}) | User: {userName}");
                errLog.AppendLine($"Browser: {agent}");

                /* Выборка информации в исключении */
                if (env.IsProduction())
                {
                    errLog.AppendLine($"Exception: {e.Message}");
                    if (e.InnerException != null)
                        errLog.AppendLine($"Inner Exception: {e.InnerException.Message}");
                    _logger.LogError(errLog.ToString());
                }
                else
                {
                    _logger.LogError(e, errLog.ToString());            // Девелоп - полное описание исключения
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { ExceptionType = e.GetType().Name, e.Message }));
            }
        }
    }
}
