using RabbitMQ.Client.Events;

namespace CarrBnk.RabbitMq.Services
{
    public interface IConsumerService
    {
        Task RegisterConsumer(string queue, EventHandler<BasicDeliverEventArgs> received);
    }
}
