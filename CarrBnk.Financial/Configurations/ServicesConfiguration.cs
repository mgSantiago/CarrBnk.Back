using Core.Repositories;
using Infra.Repositories;

namespace App.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<Core.Repositories.IFinancialPostingsRepository, Infra.Repositories.FinancialPostingsRepository>();
        }
    }
}
