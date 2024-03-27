using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NsiProjekat1.Infrastructure.Domain.Company;

public class CompanyConfiguration : IEntityTypeConfiguration<NsiProjekat1.Domain.Entities.Company>
{
    public void Configure(EntityTypeBuilder<NsiProjekat1.Domain.Entities.Company> builder)
    {
        builder.ToTable("Companies");

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        /*builder.Property<Guid>("CompanyId");
        
        builder.HasIndex("CompanyId");
        
        builder.HasOne(b => b.Company)
               .WithMany(b => b.Products)
               .HasForeignKey("CompanyId")
               .IsRequired();*/
    }
}