namespace GoodMarket.IdentityApi.Controllers
{
    /// <summary>
    /// Вход по почте
    /// </summary>
    public class EmailSignInRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}