using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.Application.Common.Interfaces;

public interface IProductService
{
    Task<ProductDetailsDto> CreateAsync(ProductCreateDto game, CancellationToken cancellationToken);
}
