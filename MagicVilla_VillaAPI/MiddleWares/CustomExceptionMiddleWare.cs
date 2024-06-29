using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace MagicVilla_VillaAPI.MiddleWares
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IWebHostEnvironment _environment;

        public CustomExceptionMiddleWare(RequestDelegate requestDelegate, IWebHostEnvironment environment)
        {
            _requestDelegate = requestDelegate;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception e)
            {
                await ProcessExption(context,e);
            }
        }

        private async Task ProcessExption(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            if (_environment.IsDevelopment())
            {
                if (exception is BadImageFormatException fileNotFoundException)
                {
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        StatusCode = context.Response.StatusCode,
                        StackTrace = exception.StackTrace,
                        Message = exception.Message
                    }));
                }
                else
                {
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        StatusCode = context.Response.StatusCode,
                        StackTrace = exception.StackTrace,
                        Message = exception.Message
                    }));
                }
            }
            else
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Hello from Error Handling Middleware"
                }));
            }

        }
    }
}
