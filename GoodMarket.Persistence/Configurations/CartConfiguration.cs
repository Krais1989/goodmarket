using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using GoodMarket.Common;
using GoodMarket.Domain.Entities;

namespace GoodMarket.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(e => e.Records)
                .HasConversion(e => SSerializer.SerializeDefault(e), e => SSerializer.DeserializeDefault<Dictionary<int, int>>(e));
        }
    }
}
