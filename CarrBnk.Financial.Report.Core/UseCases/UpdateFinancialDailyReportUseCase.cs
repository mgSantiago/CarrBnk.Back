using CarrBnk.Financial.Report.Core.Constants;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Redis.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class UpdateFinancialDailyReportUseCase : IRequestHandler<UpdateFinancialDailyReportRequest, bool>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<UpdateFinancialDailyReportUseCase> _logger;
        private readonly ICacheService _cacheService;

        public UpdateFinancialDailyReportUseCase(IFinancialReportRepository repository,
                                            ILogger<UpdateFinancialDailyReportUseCase> logger,
                                            ICacheService cacheService)
        {
            _repository = repository;
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(UpdateFinancialDailyReportRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(UpdateFinancialDailyReportUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, DateTime.Now);

            var code = await _repository.Update(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Updated | Code: {code}", nameof(UpdateFinancialDailyReportUseCase), code);

            await _cacheService.RemoveCacheAsync(RedisKeys.GetFinancialDailyReportCachedKey());

            return code;
        }
    }
}
