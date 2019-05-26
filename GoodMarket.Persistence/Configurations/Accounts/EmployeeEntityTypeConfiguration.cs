using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация юзера-сотрудника
    /// </summary>
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasOne(a => a.Profile).WithOne(p => (Employee)p.Account).HasForeignKey<Profile>(p => p.AccountId);
            //builder.HasKey(e => e.Id);
            //builder.HasIndex(e => e.AccountId).IsUnique();
            //builder.HasOne(e => e.Account).WithOne().HasForeignKey<Employee>(e => e.AccountId);
            builder.HasMany(e => e.Orders).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId);
        }
    }


}
