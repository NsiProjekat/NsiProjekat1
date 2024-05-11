using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Application.Common.Exceptions;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Common.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.EntityFrameworkCore;

namespace NsiProjekat1.Application.Products.Commands;

public record ProductCreateCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;

public class ProductCreateCommandHandler(INsiProjekat1DbContext dbContext) : IRequestHandler<ProductCreateCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies
            .Where(x => x.Id == request.Product.CompanyId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (company == null)
            throw new NotFoundException("Company does not exist.");

        var product = request.Product
            .FromCreateDtoToEntity()
            .AddCompany(company);
        
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return product.ToDto();
    }
}