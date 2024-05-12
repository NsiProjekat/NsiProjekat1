using NsiProjekat1.Application.Common.Exceptions;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Common.Mappers;
using NsiProjekat1.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using NsiProjekat1.Application.Common.Dto.Product;

namespace NsiProjekat1.Infrastructure.Services;

public class ProductService(INsiProjekat1DbContext dbContext, ICompanyService companyService) : IProductService
{
    public async Task<ProductDetailsDto> CreateAsync(ProductCreateDto product, CancellationToken cancellationToken)
    {
        var test = companyService.CreateAsync();
        var company = await dbContext.Companies
            .Where(x => x.Id == product.CompanyId)
            .FirstOrDefaultAsync(cancellationToken);

        if (company == null)
            throw new NotFoundException("Company not exist!");

        var productEntity = product.FromCreateDtoToEntity()
            .AddCompany(company);

        dbContext.Products.Add(productEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return productEntity.ToDto();
    }
}
