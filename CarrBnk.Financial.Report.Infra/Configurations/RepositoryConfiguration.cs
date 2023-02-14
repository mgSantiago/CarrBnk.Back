using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Financial.Report.Infra.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IFinancialReportRepository, FinancialReportRepository>();
        }
    }
}
