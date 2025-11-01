using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.ExceptionHandling;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var traceId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier;
        var path = context.HttpContext.Request.Path;
        
        var (title, statusCode, detail) = exception switch
        {
            ArgumentNullException notFound => 
            (
                notFound.Message, 
                StatusCodes.Status404NotFound,
                "Could not find any objects with the specified id."
                ),
            NullReferenceException notNull =>
            (
                    notNull.Message,
                    StatusCodes.Status404NotFound,
                    "Could not find any objects with the specified id."
                    ),
            ArgumentOutOfRangeException argumentOutOfRange => 
            (
                argumentOutOfRange.Message,
                StatusCodes.Status400BadRequest,
                "Id should be greater than or equal to zero."
                ),
            _ => 
            (
                "Something went wrong",
                StatusCodes.Status500InternalServerError,
                "Something went wrong, Please try again, or contact the administrator."
                )
        };

        ProblemDetails problemDetails = new ProblemDetails
        {
            Title = title,
            Status = statusCode,
            Instance = path,
            Detail = detail,
        };
        
        problemDetails.Extensions["traceId"] = traceId;
        problemDetails.Extensions["path"] = path;

        _logger.LogError(exception, "Caught exception: {message}", exception.Message);
        
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };
    }
}