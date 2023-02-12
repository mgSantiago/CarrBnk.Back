using CarrBnk.Financial.Core.UseCases;
using MediatR;

namespace CarrBnk.Financial.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatrConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateFinancialPostingsUseCase));
        }
    }
}
