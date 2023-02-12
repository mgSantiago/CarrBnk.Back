using CarrBnk.Financial.Report.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Models
{
    public record FinancialReportModel
    {
        public FinancialReportModel(ObjectId id, decimal value, FinancialPostingType financialPostingType, DateTime? creationDate)
        {
            Id = id;
            Value = value;
            FinancialPostingType = financialPostingType;
            CreationDate = creationDate;
            UpdatedDate = DateTime.UtcNow;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
    }
}
