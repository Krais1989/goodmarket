using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace GoodMarket.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Address)
                .HasConversion(
                e => SSerializer.Serialize(e),
                e => SSerializer.Deserialize<AddressDetails>(e));

            builder.Property(e => e.Records)
                .HasConversion(
                    e => SSerializer.Serialize(e),
                    e => SSerializer.Deserialize<Dictionary<int,int>>(e)
                );
        }
    }
}
