using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using IShopWeb.Domain.Models;
using IShopWeb.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IProductService _productService;
        private readonly IUserRepository _userRepository;

        public AuthService(IOptions<AuthOptions> authOptions, IProductService productService, IUserRepository userRepository)
        {
            _authOptions = authOptions;
            _productService = productService;
            _userRepository = userRepository;
        }

        IDictionary<string, string> users = new Dictionary<string, string>
            {
                { "test1", "password1" },
                { "test1", "password2" }
            };
        public async Task<AuthenticateResponseDto> Authenticate(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Login);
            if (user == null)
            {

            }
            var userHashed = PasswordHasher.VerifyPassword(loginDto.Password, user.Password);
            if (userHashed)
            {
                var token = await GenerateJwtToken(user);

                return new AuthenticateResponseDto { AccessToken = token };
            }
            else
            {

            }
            return new AuthenticateResponseDto();

        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var users = await _userRepository.GetUserByIdAsync(user.Id); //TODO rename not users

            var claims = new List<Claim>();

            claims.Add(new(ClaimTypes.Sid, users.Id.ToString()));

            claims.AddRange(users.Role.Select(x => new Claim(ClaimTypes.Role, x.Name)));

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
