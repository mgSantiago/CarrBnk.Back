using CarrBnk.BaseConfiguration.Validations;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace CarrBnk.BaseConfiguration.Configurations
{
    public static class ValidationConfiguration
    {
        public static void AddValidationConfiguration(this IServiceCollection services)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
