using System;
using GoodMarket.Domain.Entities.Identities;

namespace GoodMarket.Domain.Entities.Profiles
{
    /// <summary>
    /// Данные профиля
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FIO { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }

        public User Account { get; set; }
    }

    /// <summary>
    /// Адрес
    /// </summary>
    public class Address
    {
        public int ContryId { get; set; }
        public int TownId { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Structure { get; set; }
    }
}
