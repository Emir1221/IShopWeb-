using IShopWeb.Application.Dto;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponseDto> Authenticate(LoginDto loginDto);
    }
}
