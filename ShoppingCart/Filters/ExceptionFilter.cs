using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ShoppingCart.Common.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter()
        { 
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            // this._logger.LogError("Something went wrong", context.Exception);

            context.ExceptionHandled = true;
            if (context.Exception is InternalValidationException ex)
            {
                context.Result = new JsonResult(ex.Errors);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; 

            } else
            {
                context.Result = new JsonResult("Something went wrong");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
