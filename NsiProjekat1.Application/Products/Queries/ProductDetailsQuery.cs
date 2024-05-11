using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Common.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace NsiProjekat1.Application.Products.Queries;

public record ProductDetailsQuery(string Id) : IRequest<ProductDetailsDto?>;

public class ProductDetailsQueryHandler(INsiProjekat1DbContext dbContext) : IRequestHandler<ProductDetailsQuery, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Products
            .Include(x => x.Company)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return result?.ToDto();
    }
}