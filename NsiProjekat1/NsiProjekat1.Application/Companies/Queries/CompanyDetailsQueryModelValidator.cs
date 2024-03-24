using FluentValidation;

namespace NsiProjekat1.Application.Companies.Queries;

public class CompanyDetailsQueryModelValidator : AbstractValidator<CompanyDetailsQuery>
{
    public CompanyDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .MinimumLength(5);
    }
}