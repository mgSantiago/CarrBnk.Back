using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Authentication.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUseCaseRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
