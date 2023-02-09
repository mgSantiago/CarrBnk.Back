using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Core.Ports.Services.Interfaces;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using MediatR;

namespace CarrBnk.Authentication.Core.UseCase
{
    public class LoginUseCase : IRequestHandler<LoginUseCaseRequest, string>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public LoginUseCase(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(LoginUseCaseRequest request, CancellationToken cancellationToken)
        {
            //TODO: Fazer tratamento de erro para o request

            var user = await _userRepository.Get(request.UserName, request.Password);

            if (user == null)
            {
                return string.Empty; //TODO: Fazer tratamento de erro
            }

            return await _tokenService.GetToken(user);
        }
    }
}
