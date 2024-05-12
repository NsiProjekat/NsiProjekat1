using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NsiProjekat1.Domain.Enums;

namespace NsiProjekat1.Infrastructure.Domain.Product;

public class ProductConfiguration : IEntityTypeConfiguration<NsiProjekat1.Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<NsiProjekat1.Domain.Entities.Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property<Guid>("CompanyId");
        
        builder.HasIndex("CompanyId");
        
        builder.HasOne(b => b.Company)
               .WithMany(b => b.Products)
               .HasForeignKey("CompanyId")
               .IsRequired();
        builder.Property(b => b.Category)
            .IsRequired()
            .HasDefaultValue(Category.Tech)
            .HasConversion(p => p.Value,
                p => Category.FromValue(p));
    }
}