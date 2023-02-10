using CarrBnk.Financial.Core.Repositories;
using Core.Entities;
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

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet("{clientCode}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientCode, CancellationToken cancellationToken)
        {
            var client = await _repository.GetDailyFinancialMovements(clientCode);

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
