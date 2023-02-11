namespace CarrBnk.RabbitMq.Services
{
    public interface IPublisherService
    {
        Task Publish(string queue, string message);
    }
}
