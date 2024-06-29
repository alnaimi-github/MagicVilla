using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MagicVilla_VillaAPI.Filters
{
    public class CustomFilterException:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is FileNotFoundException fileNotFoundException)
            {
                context.Result = new ObjectResult("File Not Found But Handled in filter.")
                {
                    StatusCode = 503
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
