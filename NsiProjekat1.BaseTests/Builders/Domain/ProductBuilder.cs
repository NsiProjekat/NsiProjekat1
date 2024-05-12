using NsiProjekat1.Domain.Entities;
using NsiProjekat1.Domain.Enums;

namespace NsiProjekat1.BaseTests.Builders.Domain;

public class ProductBuilder
{
    private string _name = "-";
    private string _description = "-";
    private Category _category = Category.Tech;
    
    public Product Build() => new(_name,
        _description, _category);

    public ProductBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public ProductBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public ProductBuilder WithCategory(Category category)
    {
        _category = category;
        return this;
    }
}
