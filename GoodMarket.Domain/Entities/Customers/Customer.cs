using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Domain
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
