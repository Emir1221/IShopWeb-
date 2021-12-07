namespace IShopWeb.Application.Dto
{
    public class AuthenticateResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
