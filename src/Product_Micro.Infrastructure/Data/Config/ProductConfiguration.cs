using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Micro.Core.ProductAggregate;

namespace Product_Micro.Infrastructure.Data.Config;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(50)
      .IsRequired();
    builder.Property(p => p.Price)
      .HasDefaultValue(0)
      .IsRequired();
  }
}
