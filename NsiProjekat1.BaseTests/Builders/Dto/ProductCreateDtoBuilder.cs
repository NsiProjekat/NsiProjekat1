using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.BaseTests.Builders.Dto;

public class ProductCreateDtoBuilder
{
    //private Guid _productId;
    private Guid _companyId;
    private string _name = "-";
    private string _description = "-";
    private int _category = 1;

    public ProductCreateDtoBuilder WithCompanyId(Guid companyId)
    {
        _companyId = companyId;
        return this;
    }

    public ProductCreateDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProductCreateDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public ProductCreateDtoBuilder WithCategory(int category)
    {
        _category = category;
        return this;
    }

    public ProductCreateDto Build() => new(_companyId, _name, _description, _category);
}