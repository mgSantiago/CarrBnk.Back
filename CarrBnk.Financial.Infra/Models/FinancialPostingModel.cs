﻿using CarrBnk.Financial.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models
{
    public record FinancialPostingModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime CreationDate { get; private set; }

    }
}
