using CattleRanch.Kernel.Exceptions.Handlers;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CattleRanch.Kernel.Exceptions;
public static class DependencyContainer
{
    public static IServiceCollection AddKernelExceptions(this IServiceCollection services,
       Assembly exceptionHandlersAssembly)
    {
        services.AddScoped(typeof(ValidationService<>));

        services.AddSingleton<IWebExceptionHandler>(provider => new WebExceptionHandler(exceptionHandlersAssembly));

        return services;
    }

    public static IServiceCollection AddKernelExceptions(this IServiceCollection services) =>
        services.AddKernelExceptions(Assembly.GetExecutingAssembly());

    public static IApplicationBuilder UseWebExceptionHandlerMiddleware(this IApplicationBuilder app,
        IHostEnvironment env, IWebExceptionHandler handler)
    {
        app.Use((context, next) => WebExceptionHandlerMiddleware.WriteResponse(context, env.IsDevelopment(), handler));

        return app;
    }
}
