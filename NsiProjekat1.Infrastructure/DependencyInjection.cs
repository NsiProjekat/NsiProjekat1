using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Domain.Entities;
using NsiProjekat1.Infrastructure.Auth.Extensions;
using NsiProjekat1.Infrastructure.Configuration;
using NsiProjekat1.Infrastructure.Contexts;
using NsiProjekat1.Infrastructure.Identity;
using NsiProjekat1.Infrastructure.Services;

namespace NsiProjekat1.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);
        //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        //{
            services.AddDbContext<NsiProjekat1DbContext>(options =>
                options.UseNpgsql(dbConfiguration.ConnectionString,
                    x => x.MigrationsAssembly(typeof(NsiProjekat1DbContext).Assembly.FullName)));
        //}
        
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddUserManager<ApplicationUserManager>()
            .AddEntityFrameworkStores<NsiProjekat1DbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordlessLoginTokenProvider();

        services.AddScoped<INsiProjekat1DbContext>(provider => provider.GetRequiredService<NsiProjekat1DbContext>());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        
        return services;
    }
}