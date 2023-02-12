using CarrBnk.Financial.Report.Core.Enums;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class GetFinancialDailyReportUseCase : IRequestHandler<GetFinancialDailyReportRequest, GetFinancialDailyReportResult>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<GetFinancialDailyReportUseCase> _logger;

        public GetFinancialDailyReportUseCase(IFinancialReportRepository repository, ILogger<GetFinancialDailyReportUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetFinancialDailyReportResult> Handle(GetFinancialDailyReportRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(GetFinancialDailyReportUseCase));

            var financialPostings = await _repository.GetDailyFinancialMovements(request.Date, cancellationToken);

            _logger.LogInformation("{class} | Created | Rows: {rows}", nameof(GetFinancialDailyReportUseCase), financialPostings.Count());

            var dailyConsolidation = financialPostings.Sum(k => k.GetRealValue());
            var cashInFlowResult = financialPostings.Count(k => k.FinancialPostingType == FinancialPostingType.CashInFlow);
            var cashOutFlowResult = financialPostings.Count(k => k.FinancialPostingType == FinancialPostingType.CashOutFlow);
            var totalMovements = cashInFlowResult + cashOutFlowResult;

            return new GetFinancialDailyReportResult(dailyConsolidation, cashInFlowResult, cashOutFlowResult, totalMovements);
        }
    }
}
