using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NsiProjekat1.FunctionalTests;

namespace NsiProjekat1.FunctionalTests;

public class BaseTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    public readonly HttpClient Client;
    public readonly NsiProjekat1DbContext NsiProjekat1DbContext;
    public readonly Mock<ICompanyService> MockCompanyService;

    public BaseTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        NsiProjekat1DbContext = scope.ServiceProvider.GetRequiredService<NsiProjekat1DbContext>();
        MockCompanyService = factory.MockCompanyService;
    }
}
