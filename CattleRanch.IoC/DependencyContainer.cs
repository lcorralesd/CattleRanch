using CattleRanch.Application;
using CattleRanch.Infrastructure.EFCore;
using CattleRanch.Kernel.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CattleRanch.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddIoCServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKernelExceptions()
            .AddApplicationServices()
            .AddInfrastructureEFCoreServices(configuration);
        return services;
    }
}
