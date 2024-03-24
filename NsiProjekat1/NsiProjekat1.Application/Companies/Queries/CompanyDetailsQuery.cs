using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Common.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NsiProjekat1.Application.Common.Dto.Company;
using NsiProjekat1.Application.Products.Queries;

namespace NsiProjekat1.Application.Companies.Queries;

public record CompanyDetailsQuery(string Id) : IRequest<CompanyDetailsDto?>;

public class CompanyDetailsQueryHandler(INsiProjekat1DbContext dbContext) : IRequestHandler<CompanyDetailsQuery, CompanyDetailsDto?>
{
    public async Task<CompanyDetailsDto?> Handle(CompanyDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Companies
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return result?.ToDto();
    }
}