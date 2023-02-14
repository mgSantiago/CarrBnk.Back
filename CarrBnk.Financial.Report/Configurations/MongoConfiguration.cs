using CarrBnk.Financial.Report.Infra.Context;
using CarrBnk.Financial.Report.Infra.Models;
using CarrBnk.Financial.Report.Infra.Settings;
using MongoDB.Bson.Serialization;

namespace CarrBnk.Financial.Report.Configurations
{
    public static class MongoConfiguration
    {
        public static void AddMongoConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection(MongoSettings.Key));
            services.AddSingleton<IFinancialMongoClient, FinancialMongoClient>();

            BsonClassMap.RegisterClassMap<FinancialReportModel>(cm =>
            {
                cm.MapProperty(financialReport => financialReport.Id);
                cm.MapProperty(financialReport => financialReport.Value);
                cm.MapProperty(financialReport => financialReport.FinancialPostingType);
                cm.MapProperty(financialReport => financialReport.CreationDate);
                cm.MapProperty(financialReport => financialReport.UpdatedDate);
            });
        }
    }
}
