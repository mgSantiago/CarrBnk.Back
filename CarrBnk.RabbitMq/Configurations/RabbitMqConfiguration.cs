using CarrBnk.RabbitMq.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.RabbitMq.Configurations
{
    public static class RabbitMqConfiguration
    {
        public static void AddRabbitMqConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IConsumerService, ConsumerService>();
            services.AddSingleton<IPublisherService, PublisherService>();
        }
    }
}
