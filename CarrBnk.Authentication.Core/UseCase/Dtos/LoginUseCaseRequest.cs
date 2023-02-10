using MediatR;

namespace CarrBnk.Authentication.Core.UseCase.Dtos;

public record LoginUseCaseRequest(string UserName, string Password) : IRequest<LoginUseCaseResponse>;
