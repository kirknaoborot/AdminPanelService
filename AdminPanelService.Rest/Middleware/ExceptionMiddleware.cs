using AdminPanelService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AdminPanelService.Rest.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEmailService _emailService;
        public ExceptionMiddleware(RequestDelegate next, IEmailService emailService)
        {
            _next = next;
            _emailService = emailService;
        }

        public async Task InvoceAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await _emailService.SendEmailAsync("", exception.ToString(), "Ошибка сервиса");

        }
    }

}
