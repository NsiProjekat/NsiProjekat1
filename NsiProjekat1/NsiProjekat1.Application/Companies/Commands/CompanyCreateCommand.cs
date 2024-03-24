using NsiProjekat1.Application.Common.Dto.Company;
using NsiProjekat1.Application.Common.Exceptions;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Common.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.EntityFrameworkCore;
using NsiProjekat1.Application.Common.Dto.Company;

namespace NsiProjekat1.Application.Companies.Commands;

public record CompanyCreateCommand(CompanyCreateDto Company) : IRequest<CompanyDetailsDto?>;

public class CompanyCreateCommandHandler(INsiProjekat1DbContext dbContext) : IRequestHandler<CompanyCreateCommand, CompanyDetailsDto?>
{
    public async Task<CompanyDetailsDto?> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
    {
        var company = request.Company
            .FromCreateDtoToEntity();
        
        dbContext.Companies.Add(company);
        await dbContext.SaveChangesAsync(cancellationToken);

        return company.ToDto();
    }
}