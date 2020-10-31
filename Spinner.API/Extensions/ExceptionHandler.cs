using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Spinner.Domain.Common;
using System.Text.Json;

namespace Spinner.API.Extensions
{
    public static class ExceptionHandler
    {
        public static void UseDomainExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    string message;
                    if (context.Features.Get<IExceptionHandlerPathFeature>()?.Error is DomainException e)
                    {
                        context.Response.StatusCode = 422;
                        message = e.Message;
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        message = "Ocorreu um erro inesperado";
                    }

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { message }));
                });
            });
        }
    }
}
