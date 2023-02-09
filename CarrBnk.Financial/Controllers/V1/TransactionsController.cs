using Core.Entities;
using Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Financial.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientRepository _repository;

        public TransactionsController(IMediator mediator, IClientRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet("{clientCode}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientCode)
        {
            var client = await _repository.GetClient(clientCode);

            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = await _repository.GetClients();

            return Ok(client);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClientEntity clientEntity)
        {
            var client = await _mediator.Send(clientEntity);

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ClientEntity clientEntity)
        {
            var client = await _mediator.Send(clientEntity);

            return Ok(client);
        }

        [HttpDelete]
        public async Task<IActionResult> Update([FromBody] Guid code)
        {
            var client = await _mediator.Send(code);

            return Ok(client);
        }
    }
}
