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

            var startOfDay = request.Date.Date;
            var endOfDay = request.Date.Date.AddDays(1);

            //TODO: Adicionar Redis aqui para não ficar sempre buscando do banco, mas não sei se vai dar tempo.

            var financialPostings = await _repository.GetDailyFinancialMovements(startOfDay, endOfDay, cancellationToken);

            _logger.LogInformation("{class} | Report Created | Rows: {rows}, Date: {date}", nameof(GetFinancialDailyReportUseCase), financialPostings.Count(), request.Date.ToShortDateString());

            return new GetFinancialDailyReportResult(financialPostings);
        }
    }
}
