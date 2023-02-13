using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarrBnk.Financial.Report.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class TransactionsReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetFinancialDailyReportRequest request, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction(nameof(Get), success);
        }
    }
}
