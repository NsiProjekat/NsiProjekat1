using System.Net;
using System.Net.Http.Json;
using NsiProjekat1.BaseTests.Builders.Domain;
using NsiProjekat1.Domain.Entities;
using NsiProjekat1.Domain.Enums;
using FluentAssertions;
using FluentAssertions.Execution;
using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.FunctionalTests.Products.Queries;

public class ProductDetailsQueryTests : BaseTests
{
    [Fact]
    public async Task ProductDetailsQueryTest_GivenValidProductId_StatusOk()
    {
        //Given
        var company = new CompanyBuilder().Build();
        var product= new ProductBuilder()
            .WithDescription("bilo koji description")
            .Build()
            .AddCompany(company);

        await NsiProjekat1DbContext.Products.AddAsync(product);
        await NsiProjekat1DbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Product/Details?Id={product.Id.ToString()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ProductDetailsDto>();

        content.Should()
            .NotBeNull();

        content!.Name
            .Should()
            .Be(product.Name);

        content.CompanyName
            .Should()
            .Be(company.Name);
    }

    [Fact]
    public async Task ProductDetailsQueryTest_GivenProductIdAsNull_BadRequest()
    {
        //Given

        //When
        var response = await Client.GetAsync("/api/Product/Details");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ProductDetailsQueryTest_GivenNotExistingProductId_NotFound()
    {
        //Given
        var company = new Company("-",
            "-");
        var product = new Product("-",
            "-", Category.Tech).AddCompany(company);

        await NsiProjekat1DbContext.Products.AddAsync(product);
        await NsiProjekat1DbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Product/Details?Id={Guid.NewGuid()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    public ProductDetailsQueryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
