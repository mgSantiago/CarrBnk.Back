using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.Financial.Core.UseCases.Validators;
using FluentValidation;

namespace CarrBnk.Financial.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void AddLocalValidatorsConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateFinancialPostingsRequest>, CreateFinancialPostingsValidator>();
            services.AddScoped<IValidator<UpdateFinancialPostingsRequest>, UpdateFinancialPostingsValidator>();
        }
    }
}
