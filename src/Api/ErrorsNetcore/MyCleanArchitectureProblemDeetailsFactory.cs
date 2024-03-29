﻿using Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Api.Errors;

public class MyCleanArchitectureProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public MyCleanArchitectureProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(
        HttpContext httpContext,
        ProblemDetails problemDetails,
        int? statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode ?? 500, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceid = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        if (traceid is not null)
        {
            problemDetails.Extensions["traceid"] = traceid;
        }

        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;

        if (errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {

        return new ValidationProblemDetails(modelStateDictionary);

    }
}
