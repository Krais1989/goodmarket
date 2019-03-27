using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Domain
{
    public enum EOrderState
    {
        None,
        Pending,    // Заказ получен, но не оплачен.
        Failed,     // Ошибка при оплате
        OnHold,     // На удержании. Сток уменьшен, но требуется подтверждение платежа
        Processing, // Платёж получен, сток уменьшен. Заказ ожидает исполнения. (Не требуется, если товар виртуальный)
        Completed,  // Заказ выполнен и завершен.
        Cancelled,  // Отменён админом или покупателем
        Refunded    // Осуществлён возврат админом
    }

    public class Order : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PendingDate { get; set; }   // Дата создания
        public DateTime StatusDate { get; set; }    // Дата смены статуса
        public AddressDetails Address { get; set; } = new AddressDetails();
        public Dictionary<int, int> Records { get; set; } = new Dictionary<int, int>();
        public EOrderState State { get; set; }
    } 
}
