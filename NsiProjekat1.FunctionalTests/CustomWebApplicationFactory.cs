using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace NsiProjekat1.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public Mock<ICompanyService> MockCompanyService { get; } = new();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<NsiProjekat1DbContext>();

            var dbName = Guid.NewGuid()
                .ToString();

            services.AddDbContext<NsiProjekat1DbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
            
            services.AddScoped(_ => MockCompanyService.Object);
        });
    }
}
