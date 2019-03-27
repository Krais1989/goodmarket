using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Details)
                .HasConversion(
                e => SSerializer.Serialize(e), 
                e => SSerializer.Deserialize<PersonDetails>(e));

            builder
                .HasOne(c => c.Cart);
                //.WithOne();

            //builder.Property(e => e.Cart)
            //    .HasConversion(
            //    e => SSerializer.Serialize(e),
            //    e => SSerializer.Deserialize<Cart>(e));

        }
    }
}
