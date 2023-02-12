using CarrBnk.Financial.Infra.Context;
using CarrBnk.Financial.Infra.Settings;

namespace CarrBnk.Financial.Configurations
{
    public static class MongoConfiguration
    {
        public static void AddMongoConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection(MongoSettings.Key));
            services.AddSingleton<IFinancialMongoClient, FinancialMongoClient>();
        }
    }
}
