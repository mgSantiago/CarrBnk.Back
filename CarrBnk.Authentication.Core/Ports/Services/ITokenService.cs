using CarrBnk.Authentication.Core.Entities;

namespace CarrBnk.Authentication.Core.Ports.Services
{
    public interface ITokenService
    {
        Task<string> GetToken(User user);
    }
}
