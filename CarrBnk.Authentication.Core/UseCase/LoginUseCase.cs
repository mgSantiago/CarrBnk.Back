using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Core.Ports.Services;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using MediatR;

namespace CarrBnk.Authentication.Core.UseCase
{
    public class LoginUseCase : IRequestHandler<LoginUseCaseRequest, LoginUseCaseResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public LoginUseCase(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<LoginUseCaseResponse> Handle(LoginUseCaseRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.UserName, request.Password);

            if (user == null) return null;

            var token = await _tokenService.GetToken(user);

            return new LoginUseCaseResponse(user.Username, user.Role, token);
        }
    }
}
