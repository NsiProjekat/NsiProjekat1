using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using NsiProjekat1.BaseTests.Builders.Commands;
using NsiProjekat1.BaseTests.Builders.Domain;
using NsiProjekat1.BaseTests.Builders.Dto;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.FunctionalTests.Products.Commands;
/*
public class ProductCreateCommandTests : BaseTests
{
    [Fact]
    public async Task ProductCreateCommandTest_GivenValidProduct_StatusOk()
    {
        //Given
        var company = new CompanyBuilder().Build();

        await NsiProjekat1DbContext.Companies.AddAsync(company);
        await NsiProjekat1DbContext.SaveChangesAsync();

        var productDto = new ProductCreateDtoBuilder().WithCompanyId(company.Id)
            .Build();

        var product = new ProductCreateCommandBuilder().WithProductCreateDto(productDto)
            .Build();

        var jsonProduct = JsonSerializer.Serialize(product);
        var contentRequest = new StringContent(jsonProduct,
            Encoding.UTF8,
            "application/json");

        MockCompanyService.Setup(x => x.CreateAsync())
            .Returns("Test");

        //When
        var response = await Client.PostAsync("/api/Product/Create/create",
            contentRequest,
            new CancellationToken());

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ProductDetailsDto>();

        content.Should()
            .NotBeNull();

        MockCompanyService.Verify(x => x.CreateAsync(), Times.Once);
    }

    public ProductCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
*/