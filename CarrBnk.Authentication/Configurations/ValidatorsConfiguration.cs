using CarrBnk.Authentication.Core.UseCase.Dtos;
using CarrBnk.Authentication.Core.UseCase.Validators;
using FluentValidation;

namespace CarrBnk.Authentication.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void AddLocalValidatorsConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IValidator<LoginUseCaseRequest>, LoginUseCaseValidator>();
        }
    }
}
