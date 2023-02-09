using CarrBnk.Authentication.Core.Entities;

namespace CarrBnk.Authentication.Core.UseCase.Interfacecs
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
