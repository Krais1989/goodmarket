namespace GoodMarket.IdentityApi.Controllers
{
    /// <summary>
    /// Вход по телефону
    /// </summary>
    public class PhoneSignInRequestDto
    {
        public string Phone { get; set; }
        public string Code { get; set; }
    }
}