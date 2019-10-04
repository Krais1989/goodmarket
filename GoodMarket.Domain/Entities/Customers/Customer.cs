using System.Collections.Generic;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Domain.Entities.Profiles;

namespace GoodMarket.Domain.Entities.Customers
{
    /// <summary>
    /// Юзер-клиент
    /// </summary>
    public class Customer : Profile
    {
        //public int Id { get; set; }
        //public int AccountId { get; set; }
        //public Account Account { get; set; }
        public Cart Cart { get; set; }
        /// <summary>
        /// Заказы покупателя
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}
