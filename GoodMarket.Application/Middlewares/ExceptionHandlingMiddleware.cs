using GoodMarket.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GoodMarket.Application.Exceptions.Basics;
using Microsoft.Extensions.Hosting;

namespace GoodMarket.Application.Middlewares
{
    public class ErrorResponse
    {
        public string ExceptionType { get; set; }
        public string Message { get; set; }
        public ErrorResponse() { }

        public ErrorResponse(string exceptionType, string message)
        {
            ExceptionType = exceptionType;
            Message = message;
        }
    }

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

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                string userAgent = context.Request.Headers["User-Agent"].ToString();
                string remIp = context.Connection.RemoteIpAddress.ToString();
                string remPort = context.Connection.RemotePort.ToString();
                string locIp = context.Connection.LocalIpAddress.ToString();
                string locPort = context.Connection.LocalPort.ToString();
                bool isAuthenticated = context.User.Identity.IsAuthenticated;
                string userName = isAuthenticated ? context.User.FindFirst(ClaimTypes.Name)?.Value : "[Anonymous]";

                var reqInfo = new StringBuilder();
                reqInfo.AppendLine($"IP: ({remIp}:{remPort}) => ({locIp}:{locPort}) | User: {userName}");
                reqInfo.AppendLine($"Browser: {userAgent}");
                context.Response.ContentType = "application/json";

                _logger.LogError(e, reqInfo.ToString());

                int statusCode = StatusCodes.Status500InternalServerError;
                string exceptionType = e.GetType().Name;
                string responseMessage = e.Message;

                /* Исключение бизнес-логики */
                if (e is IGMException)
                {
                    statusCode = ((IGMException)e).ResponseCode;
                }
                /* Необработанное исключение */
                else
                {
                    statusCode = StatusCodes.Status500InternalServerError;
                    /* Выборка информации в исключении */
                    if (env.IsProduction())
                    {
                        responseMessage = "Internal server error";
                    }
                    else
                    {
                    }
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(exceptionType, responseMessage)));
            }
        }
    }
}
