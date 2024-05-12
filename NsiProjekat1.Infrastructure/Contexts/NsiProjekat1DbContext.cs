using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Domain.Entities;

namespace NsiProjekat1.Infrastructure.Contexts;

public class NsiProjekat1DbContext(DbContextOptions<NsiProjekat1DbContext> options) : IdentityDbContext<
    ApplicationUser, 
    ApplicationRole, 
    string, 
    IdentityUserClaim<string>, 
    ApplicationUserRole, 
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
    >(options), INsiProjekat1DbContext
{
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Company> Companies => Set<Company>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}