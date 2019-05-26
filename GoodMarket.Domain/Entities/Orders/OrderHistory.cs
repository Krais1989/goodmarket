using System;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Запись лога заказа
    /// </summary>
    public class OrderHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public EOrderState Status { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Description { get; set; }

        public Order Order { get; set; }
    }
}
