using System;
using System.Collections.Generic;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Domain.Entities.Employees;

namespace GoodMarket.Domain.Entities.Orders
{
    public enum EOrderState
    {
        None,
        /// <summary>
        /// Заказ создан, но не оплачен.
        /// </summary>
        Pending,
        /// <summary>
        /// Ошибка при оплате
        /// </summary>
        Failed,
        /// <summary>
        /// На удержании. Сток уменьшен, но требуется подтверждение платежа
        /// </summary>
        OnHold,
        /// <summary>
        /// Платёж получен, сток уменьшен. Заказ ожидает исполнения. (Не требуется, если товар виртуальный)
        /// </summary>
        Processing,
        /// <summary>
        /// Заказ выполнен и завершен.
        /// </summary>
        Completed,
        /// <summary>
        /// Отменён админом или покупателем
        /// </summary>
        Cancelled,
        /// <summary>
        /// Осуществлён возврат админом
        /// </summary>
        Refunded
    }

    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public EOrderState Status { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreateDate { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<OrderHistory> OrderLogs { get; set; }
    }
}
