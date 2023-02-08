using CarrBnk.Authentication.Core.Entities;
using CarrBnk.Authentication.Core.Services.Interfacecs;
using Infra.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarrBnk.Authentication.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthenticationSettings _settings;

        public TokenService(AuthenticationSettings settings)
        {
            _settings = settings;
        }
        public async Task<string> GenerateToken(User user)
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
