using CarrBnk.Financial.Report.Core.Constants;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Redis.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class CreateFinancialPostingsReportUseCase : IRequestHandler<CreateFinancialPostingsRequest, string>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<CreateFinancialPostingsReportUseCase> _logger;
        private readonly ICacheService _cacheService;

        public CreateFinancialPostingsReportUseCase(IFinancialReportRepository repository,
                                            ILogger<CreateFinancialPostingsReportUseCase> logger,
                                            ICacheService cacheService)
        {
            _repository = repository;
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<string> Handle(CreateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(CreateFinancialPostingsReportUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, DateTime.UtcNow);

            await _repository.Insert(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Created | Code: {code}", nameof(CreateFinancialPostingsReportUseCase), financialPosting.Code);

            await _cacheService.RemoveCacheAsync(RedisKeys.GetFinancialDailyReportCachedKey());

            return financialPosting.Code;
        }
    }
}
