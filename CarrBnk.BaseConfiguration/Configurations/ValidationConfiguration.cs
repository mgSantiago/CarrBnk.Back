using CarrBnk.BaseConfiguration.Validations;
using FluentValidation;
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
                //.AddValidatorsFromAssemblyContaining<AbstractValidator<IRequest<string>>>(ServiceLifetime.Transient);
            //TODO: Remover comentário
            //services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
