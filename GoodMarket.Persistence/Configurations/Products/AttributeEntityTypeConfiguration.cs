using GoodMarket.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations.Products
{
    public class AttributeEntityTypeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.ProductAttributes).WithOne(e => e.Attribute).HasForeignKey(e => e.AttributeId);
        }
    }
}

