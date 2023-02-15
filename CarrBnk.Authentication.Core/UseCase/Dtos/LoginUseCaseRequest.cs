using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Authentication.Core.UseCase.Dtos;

public class LoginUseCaseRequest : IRequest<LoginUseCaseResponse>
{
    [ExcludeFromCodeCoverage]
    public LoginUseCaseRequest(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
