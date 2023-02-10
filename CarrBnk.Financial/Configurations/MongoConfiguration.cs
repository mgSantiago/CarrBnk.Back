using CarrBnk.Financial.Infra.Context;
using CarrBnk.Financial.Infra.Settings;

namespace CarrBnk.Financial.Configurations
{
    public static class MongoConfiguration
    {
        public static void AddMongoConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("FinancialDatabase").Get<MongoSettings>();

            services.Configure<MongoSettings>(configuration.GetSection("FinancialDatabase"));
            services.AddSingleton<IFinancialMongoClient>(k => new FinancialMongoClient(mongoSettings));
        }
    }
}
