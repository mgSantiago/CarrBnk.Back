using CarrBnk.RabbitMq.Services;
using CarrBnk.RabbitMq.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.RabbitMq.Configurations
{
    public static class RabbitMqConfiguration
    {
        public static void AddRabbitMqConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqSettings>(configuration.GetSection(RabbitMqSettings.Key));

            services.AddSingleton<IConsumerService, ConsumerService>();
            services.AddSingleton<IPublisherService, PublisherService>();
        }
    }
}
