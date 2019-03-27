namespace GoodMarket.Domain
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public PersonDetails Details { get; set; }
    }

    
}
