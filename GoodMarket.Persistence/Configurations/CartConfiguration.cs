using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoodMarket.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(e => e.Records)
                .HasConversion(
                    e => SSerializer.Serialize(e),
                    e => SSerializer.Deserialize<Dictionary<int, int>>(e));
        }
    }
}
