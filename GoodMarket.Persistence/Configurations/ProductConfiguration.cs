using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace GoodMarket.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Properties)
                .HasConversion(
                    e => SSerializer.Serialize(e),
                    e => SSerializer.Deserialize<Dictionary<string,string>>(e)
                );
        }
    }


}
