using CarrBnk.Financial.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models
{
    public record FinancialPostingModel
    {
        public Guid Code { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime CreationDate { get; private set; }

    }
}
