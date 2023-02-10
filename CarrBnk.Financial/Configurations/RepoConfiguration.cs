using CarrBnk.Financial.Core.Repositories;
using Infra.Repositories;

namespace App.Configurations
{
    public static class RepoConfiguration
    {
        public static void AddRepoConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFinancialPostingsRepository, FinancialPostingsRepository>();
        }
    }
}
