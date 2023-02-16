﻿using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarrBnk.Financial.Report.Core.UseCases
{
    public class UpdateFinancialDailyReportUseCase : IRequestHandler<UpdateFinancialDailyReportRequest, bool>
    {
        private readonly IFinancialReportRepository _repository;
        private readonly ILogger<UpdateFinancialDailyReportUseCase> _logger;

        public UpdateFinancialDailyReportUseCase(IFinancialReportRepository repository,
                                            ILogger<UpdateFinancialDailyReportUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateFinancialDailyReportRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(UpdateFinancialDailyReportUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, DateTime.Now);

            var code = await _repository.Update(financialPosting, cancellationToken);

            //TODO: Adicionar Redis aqui removendo o cache do GET, mas não sei se vai dar tempo.

            _logger.LogInformation("{class} | Updated | Code: {code}", nameof(UpdateFinancialDailyReportUseCase), code);

            return code;
        }
    }
}
