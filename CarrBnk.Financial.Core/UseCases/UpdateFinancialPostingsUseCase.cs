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
    public class UpdateFinancialPostingsUseCase : IRequestHandler<UpdateFinancialPostingsRequest, bool>
    {
        private readonly IFinancialPostingsRepository _repository;
        private readonly ILogger<UpdateFinancialPostingsUseCase> _logger;
        private readonly IPublisherService _publishService;

        public UpdateFinancialPostingsUseCase(IFinancialPostingsRepository repository, 
                                            ILogger<UpdateFinancialPostingsUseCase> logger,
                                            IPublisherService publishService)
        {
            _repository = repository;
            _logger = logger;
            _publishService = publishService;
        }

        public async Task<bool> Handle(UpdateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{class} | Initializing", nameof(UpdateFinancialPostingsUseCase));

            var financialPosting = new FinancialPostings(request.Code, request.Value, request.FinancialPostingType, request.Description, null);

            var code = await _repository.Update(financialPosting, cancellationToken);

            _logger.LogInformation("{class} | Updated | Code: {code}", nameof(UpdateFinancialPostingsUseCase), code);

            await _publishService.Publish(
                nameof(Events.FinancialPostingUpdated),
                JsonConvert.SerializeObject(new FinancialPostingUpdatedEvent(financialPosting.Code, financialPosting.Value, financialPosting.FinancialPostingType))
            );

            _logger.LogInformation("{class} | {event} sent | Code: {code}", nameof(CreateFinancialPostingsUseCase), nameof(Events.FinancialPostingCreated), financialPosting.Code);

            return code;
        }
    }
}
