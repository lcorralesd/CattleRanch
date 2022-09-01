using CattleRanch.Kernel.Exceptions.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class WebExceptionHandlerMiddleware
{
    public static async Task WriteResponse(HttpContext context, bool includeDetails, IWebExceptionHandler handler)
    {
        IExceptionHandlerFeature exceptionDetail = context.Features.Get<IExceptionHandlerFeature>();

        Exception exception = exceptionDetail.Error;

        if (exception != null)
        {
            var problemDetails = await handler.Handle(exception, includeDetails);

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.StatusCode;

            var stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(stream, problemDetails);
        }
    }
}
