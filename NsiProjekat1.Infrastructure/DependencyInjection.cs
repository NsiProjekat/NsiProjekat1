using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Infrastructure.Configuration;
using NsiProjekat1.Infrastructure.Contexts;

namespace NsiProjekat1.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        services.AddDbContext<NsiProjekat1DbContext>(options =>
            options.UseNpgsql(dbConfiguration.ConnectionString,
                x => x.MigrationsAssembly(
                    typeof(NsiProjekat1DbContext).Assembly.FullName)));

        services.AddScoped<INsiProjekat1DbContext>(provider => provider.GetRequiredService<NsiProjekat1DbContext>());
        
        return services;
    }
}