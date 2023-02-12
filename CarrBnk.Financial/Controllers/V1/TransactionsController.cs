using CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Financial.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateFinancialPostingsRequest financeFlow, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(financeFlow, cancellationToken);

            return CreatedAtAction(nameof(Insert), success);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Guid code, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(code, cancellationToken);

            return Ok(success);
        }
    }
}
