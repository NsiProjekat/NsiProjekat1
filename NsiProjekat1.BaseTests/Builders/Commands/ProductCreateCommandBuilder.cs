using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Application.Products.Commands;
using NsiProjekat1.BaseTests.Builders.Dto;

namespace NsiProjekat1.BaseTests.Builders.Commands;

public class ProductCreateCommandBuilder
{
    private ProductCreateDto _productCreateDto = new ProductCreateDtoBuilder().Build();
    
    public ProductCreateCommand Build() => new(_productCreateDto);
    
    public ProductCreateCommandBuilder WithProductCreateDto(ProductCreateDto productCreateDto)
    {
        _productCreateDto = productCreateDto;
        return this;
    }

}
