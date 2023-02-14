using CarrBnk.Financial.Core.Enums;
using CarrBnk.Financial.Report.Core.CoreEvents;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.RabbitMq.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;

namespace CarrBnk.Financial.Report.Infra.Consumers
{
    public class FinancialPostingUpdatedConsumer : BackgroundService
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger<FinancialPostingUpdatedConsumer> _logger;
        private readonly IFinancialReportRepository _repository;

        public FinancialPostingUpdatedConsumer(IConsumerService consumerService, 
                                            ILogger<FinancialPostingUpdatedConsumer> logger,
                                            IFinancialReportRepository repository)
        {
            _consumerService = consumerService;
            _logger = logger;
            _repository = repository;
        }

        private void Consume(object? sender, BasicDeliverEventArgs e)
        {
            _logger.LogInformation("{class} | Consume!", nameof(FinancialPostingUpdatedConsumer));

            var body = e.Body.ToArray();

            var ev = JsonConvert.DeserializeObject<FinancialPostingUpdatedEvent>(Encoding.UTF8.GetString(body));

            if(ev == null)
            {
                _logger.LogWarning("{class} | Event null!", nameof(FinancialPostingUpdatedConsumer));
                return;
            }
            
            _repository.Update(new FinancialPostings(ev.Code, ev.Value, ev.FinancialPostingType, null), new CancellationToken());
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await new TaskFactory().StartNew(k => _consumerService.RegisterConsumer(nameof(Events.FinancialPostingCreated), Consume), TaskCreationOptions.LongRunning);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("{class} | ExecuteAsync | {time}", nameof(FinancialPostingUpdatedConsumer), DateTimeOffset.UtcNow);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
