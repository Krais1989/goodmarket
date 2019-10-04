namespace GoodMarket.Domain.Entities.Shared
{
    public class PersonDetails
    {
        public enum EGender { None, Male, Female }

        public string Name { get; set; }
        public int Age { get; set; }
        public EGender Gender { get; set; }
        public string PhoneNumber { get; set; }
    }

}
