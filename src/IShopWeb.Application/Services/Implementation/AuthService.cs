using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using IShopWeb.Domain.Models;
using Mfc.Health.Corner.Common;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly IOptions<AuthOptions> _authOptions;

        public AuthService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
        }

        IDictionary<string, string> users = new Dictionary<string, string>
            {
                { "test1", "password1" },
                { "test1", "password2" }
            };
        public async Task<AuthenticateResponseDto> Authenticate(LoginDto loginDto)
        {

        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var roleIds = await _userRoleRepository.GetRoleIdsByUserIdAsync(user.Id);

            var roles = await _roleRepository.GetRolesByIdsAsync(roleIds.ToList());

            var claims = new List<Claim>();

            claims.Add(new(ClaimTypes.Sid, user.Id));

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x.Name)));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
