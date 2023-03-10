using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Financial.Report.Core.UseCases.Validators;
using FluentValidation;

namespace CarrBnk.Financial.Report.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void AddLocalValidatorsConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetFinancialDailyReportRequest>, GetFinancialDailyReportValidator>();
        }
    }
}
