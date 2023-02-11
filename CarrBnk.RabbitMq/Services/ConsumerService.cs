using CarrBnk.RabbitMq.Registers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CarrBnk.RabbitMq.Services
{
    internal class ConsumerService : IConsumerService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILogger<ConsumerService> _logger;

        private IConnection _connection;
        private IConnection Connection
        {
            get
            {
                if(_connection != null && _connection.IsOpen) return _connection;

                _connection = _connectionFactory.CreateConnection();

                return _connection;
            }
        }

        public ConsumerService(ILogger<ConsumerService> logger, string connectionString)
        {
            _logger = logger;
            _connectionFactory = new ConnectionFactory { HostName = connectionString };
        }

        public async Task RegisterConsumer(string queue, EventHandler<BasicDeliverEventArgs> received)
        {
            var channel = Connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _logger.LogInformation("{class} | Waiting for messages!", nameof(ConsumerService));

            var consumer = new EventingBasicConsumer(channel);
            
            consumer.Received += received;

            consumer.Shutdown += (model, ev) =>
            {
                _logger.LogWarning("{class} | Consumer Shutdown! | Cause: {Cause}", nameof(ConsumerService), JsonConvert.SerializeObject(ev.Cause));
            };

            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);

            await Task.Yield();
        }
    }
}
