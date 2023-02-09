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
        private readonly IFinancialPostingsRepository _repository;

        public TransactionsController(IMediator mediator, IFinancialPostingsRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet("{clientCode}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientCode, CancellationToken cancellationToken)
        {
            var client = await _repository.GetClient(clientCode);

            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var client = await _repository.GetClients();

            return Ok(client);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FinancialPostings clientEntity, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(clientEntity);

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] FinancialPostings clientEntity, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(clientEntity);

            return Ok(client);
        }

        [HttpDelete]
        public async Task<IActionResult> Update([FromBody] Guid code, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(code);

            return Ok(client);
        }
    }
}
