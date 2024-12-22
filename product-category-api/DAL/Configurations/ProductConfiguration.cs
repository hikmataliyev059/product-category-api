using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product_category_api.Models;

namespace product_category_api.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);
    }
}