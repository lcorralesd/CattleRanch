using CattleRanch.Application.Interfaces;
using CattleRanch.Infrastructure.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CattleRanch.Infrastructure.EFCore;
public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<CattleRanchDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultSQLServer")!));

        services.AddScoped<IApplicationDbContext, CattleRanchDbContext>();

        return services;
    }
}
