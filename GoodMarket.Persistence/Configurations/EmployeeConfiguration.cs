using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace GoodMarket.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.Email).IsUnique();
            //builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Details)
                .HasConversion(
                e => SSerializer.Serialize(e),
                e => SSerializer.Deserialize<PersonDetails>(e));
        }
    }
}
