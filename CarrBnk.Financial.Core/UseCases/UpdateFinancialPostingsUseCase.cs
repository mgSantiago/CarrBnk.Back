using CarrBnk.Financial.Core.Entities;
using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Core.UseCases
{
    public class UpdateFinancialPostingsUseCase : IRequestHandler<UpdateFinancialPostingsRequest, bool>
    {
        private readonly IFinancialPostingsRepository _repository;
        private readonly ILogger<UpdateFinancialPostingsUseCase> _logger;

        public UpdateFinancialPostingsUseCase(IFinancialPostingsRepository repository, ILogger<UpdateFinancialPostingsUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(UpdateFinancialPostingsUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, request.Description, null);

            var code = await _repository.Update(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Updated | Code: {code}", nameof(UpdateFinancialPostingsUseCase), code);

            return code;
        }
    }
}
