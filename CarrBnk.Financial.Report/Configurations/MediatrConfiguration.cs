using CarrBnk.Financial.Report.Core.UseCases;
using MediatR;

namespace CarrBnk.Financial.Report.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatrConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetFinancialDailyReportUseCase));
        }
    }
}
