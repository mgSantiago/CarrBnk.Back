using CarrBnk.Financial.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Models
{
    public record FinancialPostingModel
    {
        public FinancialPostingModel(string? id, decimal value, FinancialPostingType financialPostingType, string description, DateTime creationDate)
        {
            Id = id ?? string.Empty;
            Value = value;
            FinancialPostingType = financialPostingType;
            Description = description;
            CreationDate = creationDate;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime CreationDate { get; private set; }

    }
}
