using CarrBnk.Financial.Report.Core.Enums;
using CarrBnk.Financial.Report.Infra.Serializer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CarrBnk.Financial.Report.Infra.Models
{
    public record FinancialReportModel
    {
        public FinancialReportModel(ObjectId id, decimal value, FinancialPostingType financialPostingType, DateTime? creationDate)
        {
            Id = id;
            Value = value;
            FinancialPostingType = financialPostingType;
            CreationDate = creationDate ?? DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        [BsonSerializer(typeof(MongoDBDateTimeSerializer<DateTime>))]
        public DateTime CreationDate { get; private set; }
        [BsonSerializer(typeof(MongoDBDateTimeSerializer<DateTime>))]
        public DateTime UpdatedDate { get; private set; }
    }
}
