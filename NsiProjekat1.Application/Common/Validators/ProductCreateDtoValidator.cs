using NsiProjekat1.Domain.Common.Extensions;
using NsiProjekat1.Domain.Enums;
using FluentValidation;
using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.Application.Common.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.CompanyId)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MaximumLength(350);
        
        RuleFor(x => x.Category)
            .Must(t => Category.TryFromValue(t, out _))
            .WithMessage(_ => $"Category is not valid, category must be in list of: {EnumExtensions.CategoryValidList}");

    }
}
