using CarrBnk.Financial.Core.CoreEvents;
using CarrBnk.Financial.Core.Entities;
using CarrBnk.Financial.Core.Enums;
using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.RabbitMq.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarrBnk.Financial.Core.UseCases
{
    public class CreateFinancialPostingsUseCase : IRequestHandler<CreateFinancialPostingsRequest, string>
    {
        private readonly IFinancialPostingsRepository _repository;
        private readonly ILogger<CreateFinancialPostingsUseCase> _logger;
        private readonly IPublisherService _publishService;

        public CreateFinancialPostingsUseCase(IFinancialPostingsRepository repository, 
                                            ILogger<CreateFinancialPostingsUseCase> logger,
                                            IPublisherService publishService)
        {
            _repository = repository;
            _logger = logger;
            _publishService = publishService;
        }

        public async Task<string> Handle(CreateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(CreateFinancialPostingsUseCase));

            var financialPosting = new FinancialPostings(null, request.Value, request.FinancialPostingType, request.Description, DateTime.UtcNow);

            await _repository.Insert(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Created | Code: {code}", nameof(CreateFinancialPostingsUseCase), financialPosting.Code);

            await _publishService.Publish(
                nameof(Events.FinancialPostingCreated), 
                JsonConvert.SerializeObject(new FinancialPostingCreatedEvent(financialPosting.Code, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.CreationDate.Value))
            );
            _logger.LogInformation("{class} | {event} sent | Code: {code}", nameof(CreateFinancialPostingsUseCase), nameof(Events.FinancialPostingCreated), financialPosting.Code);

            return financialPosting.Code;
        }
    }
}
