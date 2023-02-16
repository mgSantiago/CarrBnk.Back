using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class CreateFinancialPostingsReportUseCase : IRequestHandler<CreateFinancialPostingsRequest, string>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<CreateFinancialPostingsReportUseCase> _logger;

        public CreateFinancialPostingsReportUseCase(IFinancialReportRepository repository,
                                            ILogger<CreateFinancialPostingsReportUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(CreateFinancialPostingsReportUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, DateTime.UtcNow);

            await _repository.Insert(financialPosting, cancellationToken);

            //TODO: Adicionar Redis aqui removendo o cache do GET, mas não sei se vai dar tempo.

            _logger.LogInformation("{class} | Created | Code: {code}", nameof(CreateFinancialPostingsReportUseCase), financialPosting.Code);

            return financialPosting.Code;
        }
    }
}
