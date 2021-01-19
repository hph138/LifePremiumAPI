using LifePremiumAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace LifePremiumAPI.Middleware
{
    public static class CustomExceptionMiddleware
    {
        public static void ConfigCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomException>();
        }

        public static void ConfigExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(err =>
            {
                err.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        
                        await context.Response.WriteAsync(new CustomError()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Something went wrong."
                        }.ToString());
                    }
                });
            });
        }


    }
}
