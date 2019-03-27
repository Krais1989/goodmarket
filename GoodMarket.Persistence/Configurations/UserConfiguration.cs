using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Details)
                .HasConversion(
                e => SSerializer.Serialize(e),
                e => SSerializer.Deserialize<PersonDetails>(e));
            builder.Property(e => e.Role);
        }
    }
}
