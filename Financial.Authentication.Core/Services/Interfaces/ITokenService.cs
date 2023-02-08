using CarrBnk.Authentication.Core.Entities;

namespace CarrBnk.Authentication.Core.Services.Interfacecs
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
