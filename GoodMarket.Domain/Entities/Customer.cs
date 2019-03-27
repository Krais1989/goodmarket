namespace GoodMarket.Domain
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public PersonDetails Details { get; set; } = new PersonDetails();
        //public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
