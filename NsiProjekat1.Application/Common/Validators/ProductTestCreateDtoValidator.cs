using NsiProjekat1.Application.Common.Dto.Game;
using NsiProjekat1.Application.Games.Commands;
using NsiProjekat1.Domain.Common.Extensions;
using NsiProjekat1.Domain.Enums;
using FluentValidation;
using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Application.Products.Commands;

namespace NsiProjekat1.Application.Common.Validators;

public class ProductTestCreateDtoValidator : AbstractValidator<ProductTestCreateDto>
{
    public ProductTestCreateDtoValidator()
    {
        RuleFor(x => x.Json)
            .Must(t => t.TryDeserializeJson<ProductCreateCommand>(out _,
                SerializerExtensions.SettingsWebOptions))
            .WithMessage("Json is not in good format");

    }
}
