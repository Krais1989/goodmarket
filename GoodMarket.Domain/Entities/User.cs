using System;
using System.Security.Claims;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Системный пользователь
    /// </summary>
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public PersonDetails Details { get; set; } = new PersonDetails();
        public int Role { get; set; }
    }
}
