using CarrBnk.Financial.Report.Core.Constants;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Redis.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class GetFinancialDailyReportUseCase : IRequestHandler<GetFinancialDailyReportRequest, GetFinancialDailyReportResult>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<GetFinancialDailyReportUseCase> _logger;
        private readonly ICacheService _cacheService;

        public GetFinancialDailyReportUseCase(IFinancialReportRepository repository, 
                                            ILogger<GetFinancialDailyReportUseCase> logger,
                                            ICacheService cacheService)
        {
            _repository = repository;
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<GetFinancialDailyReportResult> Handle(GetFinancialDailyReportRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(GetFinancialDailyReportUseCase));

            var startOfDay = request.Date.Date;
            var endOfDay = request.Date.Date.AddDays(1);

            var financialDailyReportCacheKey = RedisKeys.GetFinancialDailyReportCachedKey(startOfDay.ToString(), endOfDay.ToString());

            var finCached = await _cacheService.GetCacheAsync<IEnumerable<FinancialPostings>>(financialDailyReportCacheKey);

            if(finCached != null && finCached.Any()) return new GetFinancialDailyReportResult(finCached);

            var financialPostings = await _repository.GetDailyFinancialMovements(startOfDay, endOfDay, cancellationToken);

            await _cacheService.AddCacheAsync(financialDailyReportCacheKey, financialPostings);

            _logger.LogInformation("{class} | Report Created | Rows: {rows}, Date: {date}", nameof(GetFinancialDailyReportUseCase), financialPostings.Count(), request.Date.ToShortDateString());

            return new GetFinancialDailyReportResult(financialPostings);
        }
    }
}
