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
    public class FinancialPostingCreatedConsumer : BackgroundService
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger<FinancialPostingCreatedConsumer> _logger;
        private readonly IFinancialReportRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public FinancialPostingCreatedConsumer(IConsumerService consumerService, 
                                            ILogger<FinancialPostingCreatedConsumer> logger,
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
            _logger.LogInformation("{class} | Consume!", nameof(FinancialPostingCreatedConsumer));

            try
            {
                var body = e.Body.ToArray();

                var ev = JsonConvert.DeserializeObject<FinancialPostingCreatedEvent>(Encoding.UTF8.GetString(body));

                if (ev == null)
                {
                    _logger.LogWarning("{class} | Event null!", nameof(FinancialPostingCreatedConsumer));
                    return;
                }

                GetMediator().Send(new CreateFinancialPostingsRequest(ev.Code, ev.FinancialPostingType, ev.Value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{class} | Error!", nameof(FinancialPostingCreatedConsumer));
            }
        }

        private IMediator GetMediator()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetService<IMediator>();
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
