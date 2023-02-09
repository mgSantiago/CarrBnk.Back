using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.BaseConfiguration.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatrConfiguration<T>(this IServiceCollection services)
        {
            services.AddMediatR(typeof(T));
        }
    }
}
