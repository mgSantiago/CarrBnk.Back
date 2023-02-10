using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarrBnk.BaseConfiguration.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatrConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
