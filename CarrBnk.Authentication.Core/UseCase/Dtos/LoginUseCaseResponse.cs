using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Authentication.Core.UseCase.Dtos
{
    [ExcludeFromCodeCoverage]
    public record LoginUseCaseResponse(String Username, String Role, String Token);
}
