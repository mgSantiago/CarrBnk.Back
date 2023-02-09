using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Dtos.Requests;
using CarrBnk.Authentication.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Authentication.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        public AuthenticationController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginRequest request)
        {
            var user = await _userRepository.Get(request.UserName, request.Password);

            if (user == null) //TODO: Melhorar mensagem de erro.
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = await _mediator.Send(user);

            return new LoginResponse(user.Username, token);
        }
    }
}
