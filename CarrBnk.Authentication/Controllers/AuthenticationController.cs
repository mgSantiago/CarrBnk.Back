using CarrBnk.Authentication.Core.Repositories;
using CarrBnk.Authentication.Core.Services.Interfacecs;
using CarrBnk.Authentication.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public AuthenticationController(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginRequest request)
        {
            // Recupera o usuário
            var user = _userRepository.Get(request.UserName, request.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = await _tokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user,
                token
            };
        }
    }
}
