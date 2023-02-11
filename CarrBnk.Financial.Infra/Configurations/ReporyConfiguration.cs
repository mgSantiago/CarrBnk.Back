using CarrBnk.Financial.Core.Ports.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Financial.Infra.Configurations
{
    public static class ReporyConfiguration
    {
        public static void AddRepoConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFinancialPostingsRepository, FinancialPostingsRepository>();
        }
    }
}
