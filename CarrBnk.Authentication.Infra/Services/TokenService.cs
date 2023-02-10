using CarrBnk.Authentication.Core.Entities;
using CarrBnk.Authentication.Core.Ports.Services.Interfaces;
using CarrBnk.Authentication.Infra.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarrBnk.Authentication.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthenticationSettings _settings;

        public TokenService(IOptionsMonitor<AuthenticationSettings> settings)
        {
            _settings = settings.CurrentValue;
        }
        public async Task<string> GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.ExpirationTime),
                Issuer = _settings.Issuer,
                Audience = _settings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            await Task.Yield();

            return tokenHandler.WriteToken(token);
        }
    }
}
