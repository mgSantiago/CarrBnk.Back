using RabbitMQ.Client.Events;

namespace CarrBnk.RabbitMq.Services
{
    public interface IConsumerService
    {
        void RegisterConsumer(string queue, EventHandler<BasicDeliverEventArgs> received);
    }
}
