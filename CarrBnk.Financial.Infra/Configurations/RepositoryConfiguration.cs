using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Financial.Infra.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void AddRepoConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFinancialPostingsRepository, FinancialPostingsRepository>();
        }
    }
}
