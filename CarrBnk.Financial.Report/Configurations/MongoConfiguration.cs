using CarrBnk.Financial.Report.Infra.Context;
using CarrBnk.Financial.Report.Infra.Settings;

namespace CarrBnk.Financial.Report.Configurations
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
