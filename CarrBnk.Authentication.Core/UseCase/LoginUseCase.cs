using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Core.Ports.Services;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Authentication.Core.UseCase
{
    public class LoginUseCase : IRequestHandler<LoginUseCaseRequest, LoginUseCaseResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginUseCase> _logger;

        public LoginUseCase(ITokenService tokenService, 
                        IUserRepository userRepository,
                        ILogger<LoginUseCase> logger)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<LoginUseCaseResponse> Handle(LoginUseCaseRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(LoginUseCase));

            var user = await _userRepository.Get(request.UserName, request.Password);

            _logger.LogInformation("{class} | UserId: {userId}", nameof(LoginUseCase), user?.Id);

            if (user == null) return null;

            var token = await _tokenService.GetToken(user);

            return new LoginUseCaseResponse(user.Username, user.Role, token);
        }
    }
}
