using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    public class ProductAttributeEntityTypeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(e => new { e.ProductId, e.AttributeId });
            builder.HasOne(e => e.Product).WithMany(e => e.ProductAttributes).HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Attribute).WithMany(e => e.ProductAttributes).HasForeignKey(e => e.AttributeId);
        }
    }
}

