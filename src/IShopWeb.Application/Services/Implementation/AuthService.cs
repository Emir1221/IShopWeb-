using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {

        IDictionary<string, string> users = new Dictionary<string, string>
            {
                { "test1", "password1" },
                { "test1", "password2" }
            };
        public async Task<AuthenticateResponseDto> Authenticate(LoginDto loginDto)
        {

        }
    }
}
