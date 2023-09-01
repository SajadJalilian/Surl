using Microsoft.EntityFrameworkCore;
using surl.Shared.Persistence;

namespace surl.Shared.Api.Extensions.DependencyInjections;

public static class DatabaseInjection
{
    public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConnection")));

        return services;
    }
}