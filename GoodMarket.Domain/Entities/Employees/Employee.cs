using System.Collections.Generic;
using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Domain.Entities.Profiles;

namespace GoodMarket.Domain.Entities.Employees
{
    /// <summary>
    /// Юзер-сотрудник
    /// </summary>
    public class Employee : Profile
    {
        //public int Id { get; set; }
        //public int AccountId { get; set; }
        //public Account Account { get; set; }

        /// <summary>
        /// Заказы обработчика
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}
