using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация Заказа
    /// </summary>
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.HasOne(o => o.Employee).WithMany(e => e.Orders).HasForeignKey(e => e.EmployeeId);
            builder.HasMany(o => o.OrderProducts).WithOne(op => op.Order).HasForeignKey(op => op.OrderId);
            builder.HasMany(e => e.OrderLogs).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
        }
    }
}

