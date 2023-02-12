using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases.Dtos;
using Core.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Core.UseCases
{
    public class CreateFinancialPostingsUseCase : IRequestHandler<CreateFinancialPostingsRequest, string>
    {
        private readonly IFinancialPostingsRepository _repository;
        private readonly ILogger<CreateFinancialPostingsUseCase> _logger;

        public CreateFinancialPostingsUseCase(IFinancialPostingsRepository repository, ILogger<CreateFinancialPostingsUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(CreateFinancialPostingsUseCase));

            var financialPosting = new FinancialPostings(null, request.Value, request.FinancialPostingType, request.Description, DateTime.UtcNow);

            var code = await _repository.Insert(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Created | Code: {code}", nameof(CreateFinancialPostingsUseCase), code);

            return code;
        }
    }
}
