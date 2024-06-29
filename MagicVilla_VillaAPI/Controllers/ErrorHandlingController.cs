using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("ErrorHandling")]
    [ApiController]
    [AllowAnonymous]
    [ApiVersionNeutral]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorHandlingController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ErrorHandlingController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [Route("ProcessError")]
        public IActionResult ProcessError()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (feature?.Error is FileNotFoundException fileNotFoundException)
            {
                // Handle specific error (FileNotFoundException)
                if (_hostEnvironment.IsDevelopment())
                {
                    return Problem(
                        detail: fileNotFoundException.StackTrace,
                        title: fileNotFoundException.Message,
                        instance: _hostEnvironment.EnvironmentName);
                }
                else
                {
                    return Problem(
                        detail: "The requested file was not found.",
                        title: "File Not Found",
                        statusCode: StatusCodes.Status404NotFound,
                        instance: _hostEnvironment.EnvironmentName);
                }
            }
            else if (feature?.Error != null)
            {
                // Handle other types of errors
                if (_hostEnvironment.IsDevelopment())
                {
                    return Problem(
                        detail: feature.Error.StackTrace,
                        title: feature.Error.Message,
                        instance: _hostEnvironment.EnvironmentName);
                }
                else
                {
                    return Problem(
                        detail: "An unexpected error occurred.",
                        title: "Internal Server Error",
                        statusCode: StatusCodes.Status500InternalServerError,
                        instance: _hostEnvironment.EnvironmentName);
                }
            }
            else
            {
                // Fallback to generic problem for unknown errors
                return Problem(
                    detail: "An unexpected error occurred.",
                    title: "Internal Server Error",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: _hostEnvironment.EnvironmentName);
            }
        }
    }
}
