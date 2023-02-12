using CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Dtos;
using CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Validations;
using FluentValidation;

namespace CarrBnk.Financial.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void AddLocalValidatorsConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateFinancialPostingsRequest>, CreateFinancialPostingsValidation>();
        }
    }
}
