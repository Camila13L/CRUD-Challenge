using System;
using System.Diagnostics;
using CRUD.Challenge.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace CRUD.Challenge.Api.Errors;

public class CRUDChallengeProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public CRUDChallengeProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        this._options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }



    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        statusCode ??= 500;
        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if (title != null)
        {
            problemDetails.Title = title;
        }
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
        return problemDetails;

    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        throw new NotImplementedException();
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        string traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier!;

        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        List<Error>? errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;

        if (errors != null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(x => x.Code));
        }
    }
}

