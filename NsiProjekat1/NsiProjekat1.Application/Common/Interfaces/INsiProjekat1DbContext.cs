using Microsoft.EntityFrameworkCore;
using NsiProjekat1.Domain.Entities;

namespace NsiProjekat1.Application.Common.Interfaces;

public interface INsiProjekat1DbContext
{
    public DbSet<Product> Products { get; }
    public DbSet<Company> Companies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}