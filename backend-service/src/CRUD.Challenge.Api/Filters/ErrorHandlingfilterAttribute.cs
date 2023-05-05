using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUD.Challenge.Api.Filters;

public class ErrorHandlingfilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        Exception exception = context.Exception;

        ProblemDetails problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred",
            Status = (int)HttpStatusCode.InternalServerError,
        };

        var errorResult = new { error = "" };
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;



    }
}

