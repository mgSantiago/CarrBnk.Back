using MediatR;

namespace CarrBnk.Authentication.Core.UseCase.Dtos;

public class LoginUseCaseRequest : IRequest<LoginUseCaseResponse>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
