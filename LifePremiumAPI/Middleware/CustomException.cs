using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using LifePremiumAPI.Model;

namespace LifePremiumAPI.Middleware
{
    public class CustomException
    {
        private readonly RequestDelegate _reqDelegate;
        public CustomException(RequestDelegate reqDelegate)
        {
            _reqDelegate = reqDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _reqDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new CustomError()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Something went wrong here"
            }.ToString());
        }


    }
}
