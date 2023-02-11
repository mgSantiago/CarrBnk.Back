using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace CarrBnk.RabbitMq.Services
{
    internal class PublisherService : IPublisherService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILogger<ConsumerService> _logger;

        private IConnection _connection;
        private IConnection Connection
        {
            get
            {
                if (_connection != null && _connection.IsOpen) return _connection;

                _connection = _connectionFactory.CreateConnection();

                return _connection;
            }
        }

        public PublisherService(ILogger<ConsumerService> logger, string connectionString)
        {
            _logger = logger;
            _connectionFactory = new ConnectionFactory { HostName = connectionString };
        }

        public async Task Publish(string queue, string message)
        {
            using var channel = Connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queue,
                                 basicProperties: null,
                                 body: body);

            _logger.LogInformation("{class} | Message sent! | Queue: {queue}", nameof(PublisherService), queue);

            await Task.Yield();
        } 
    }
}
