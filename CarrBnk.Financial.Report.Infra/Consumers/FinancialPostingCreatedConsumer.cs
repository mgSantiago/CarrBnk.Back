using CarrBnk.Financial.Core.Enums;
using CarrBnk.RabbitMq.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;

namespace CarrBnk.Financial.Report.Infra.Consumers
{
    public class FinancialPostingCreatedConsumer : BackgroundService
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger<FinancialPostingCreatedConsumer> _logger;

        public FinancialPostingCreatedConsumer(IConsumerService consumerService, ILogger<FinancialPostingCreatedConsumer> logger)
        {
            _consumerService = consumerService;
            _logger = logger;
        }

        private void Consume(object? sender, BasicDeliverEventArgs e)
        {
            _logger.LogInformation("{class} | Consume", nameof(FinancialPostingCreatedConsumer));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await new TaskFactory().StartNew(k => _consumerService.RegisterConsumer(nameof(Events.FinancialPostingCreated), Consume), TaskCreationOptions.LongRunning);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("{class} | ExecuteAsync | {time}", nameof(FinancialPostingCreatedConsumer), DateTimeOffset.UtcNow);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
