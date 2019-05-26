using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация записи лога заказа
    /// </summary>
    public class OrderHistoryEntityTypeConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Order).WithMany(e => e.OrderLogs).HasForeignKey(e => e.OrderId);
        }
    }
}

