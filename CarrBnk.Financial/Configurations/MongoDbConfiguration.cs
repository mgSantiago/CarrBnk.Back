using CarrBnk.Financial.Infra.Context;
using CarrBnk.Financial.Infra.Settings;
using MongoDB.Driver;

namespace CarrBnk.Financial.Configurations
{
    public static class MongoDbConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("FinancialDatabase").Get<MongoSettings>();

            services.AddSingleton<IFinancialMongoClient>(k => new FinancialMongoClient(mongoSettings));
        }
    }
}
