using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    public class ErrorHanldingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails()
            {
                Type = "rfc7231#sec-661",
                Title = "An error occurred while processing your request!",//exception.Message,
                Status = (int)HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(new { error = "An error occurred while processing yoru request" })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
