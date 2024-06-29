using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace MagicVilla_VillaAPI.Extensions
{
    public static class CustomExceptionExtensions
    {
        public static void HandleError(this IApplicationBuilder app,bool isDevelopment)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    if (feature != null)
                    {
                        var exception = feature.Error;
                        if (isDevelopment)
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
                });
            });

        }
    }
}
