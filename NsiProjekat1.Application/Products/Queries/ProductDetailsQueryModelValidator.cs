using FluentValidation;

namespace NsiProjekat1.Application.Products.Queries;

public class ProductDetailsQueryModelValidator : AbstractValidator<ProductDetailsQuery>
{
    public ProductDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .MinimumLength(5);
    }
}