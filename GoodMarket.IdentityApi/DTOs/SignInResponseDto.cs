namespace GoodMarket.IdentityApi.Controllers
{
    /// <summary>
    /// Результат входа - токен
    /// </summary>
    public class SignInResponseDto
    {
        public string Login { get; set; }
        public string Token { get; set; }
    }
}