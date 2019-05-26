using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация юзера-клиента
    /// </summary>
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder.HasKey(e => e.Id);
            //builder.HasIndex(e => e.AccountId).IsUnique();
            //builder.HasOne(e => e.Account).WithOne().HasForeignKey<Customer>(e => e.AccountId);
            builder.HasMany(e => e.Orders).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
        }
    }


}
