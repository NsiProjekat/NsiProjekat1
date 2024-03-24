using NsiProjekat1.Application.Common.Exceptions;
using NsiProjekat1.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NsiProjekat1.Application.Products.Commands
{
    public record ProductDeleteCommand(Guid ProductId) : IRequest<bool>;

    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, bool>
    {
        private readonly INsiProjekat1DbContext _dbContext;

        public ProductDeleteCommandHandler(INsiProjekat1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

            if (product == null)
                throw new NotFoundException("Product not found.");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}