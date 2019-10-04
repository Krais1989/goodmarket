using GoodMarket.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations.Products
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Products).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
            builder.HasMany(e => e.Childs).WithOne(e => e.Parent).HasForeignKey(e => e.ParentId);
        }
    }
}

