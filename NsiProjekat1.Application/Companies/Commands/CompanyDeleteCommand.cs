using NsiProjekat1.Application.Common.Exceptions;
using NsiProjekat1.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NsiProjekat1.Application.Companies.Commands
{
    public record CompanyDeleteCommand(Guid CompanyId) : IRequest<bool>;

    public class CompanyDeleteCommandHandler : IRequestHandler<CompanyDeleteCommand, bool>
    {
        private readonly INsiProjekat1DbContext _dbContext;

        public CompanyDeleteCommandHandler(INsiProjekat1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CompanyDeleteCommand request, CancellationToken cancellationToken)
        {
            var company = await _dbContext.Companies
                .FirstOrDefaultAsync(p => p.Id == request.CompanyId, cancellationToken);

            if (company == null)
                throw new NotFoundException("Company not found.");

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}