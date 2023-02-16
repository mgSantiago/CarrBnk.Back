using CarrBnk.Financial.Report.Core.Constants.Enums;
using CarrBnk.Financial.Report.Core.CoreEvents;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.RabbitMq.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;

        public FinancialPostingUpdatedConsumer(IConsumerService consumerService, 
                                            ILogger<FinancialPostingUpdatedConsumer> logger,
                                            IFinancialReportRepository repository,
                                            IServiceProvider serviceProvider)
        {
            _consumerService = consumerService;
            _logger = logger;
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        private void Consume(object? sender, BasicDeliverEventArgs e)
        {
            _logger.LogInformation("{class} | Consume!", nameof(FinancialPostingUpdatedConsumer));

            try
            {
                var body = e.Body.ToArray();

                var ev = JsonConvert.DeserializeObject<FinancialPostingUpdatedEvent>(Encoding.UTF8.GetString(body));

                if (ev == null)
                {
                    _logger.LogWarning("{class} | Event null!", nameof(FinancialPostingUpdatedConsumer));
                    return;
                }

                GetMediator().Send(new UpdateFinancialDailyReportRequest(ev.Code, ev.Value, ev.FinancialPostingType));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{class} | Error!", nameof(FinancialPostingUpdatedConsumer));
            }
        }

        private IMediator GetMediator()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetService<IMediator>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await new TaskFactory().StartNew(k => _consumerService.RegisterConsumer(nameof(Events.FinancialPostingUpdated), Consume), TaskCreationOptions.LongRunning);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("{class} | ExecuteAsync | {time}", nameof(FinancialPostingUpdatedConsumer), DateTimeOffset.UtcNow);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
