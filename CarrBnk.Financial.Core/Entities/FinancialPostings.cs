using CarrBnk.Financial.Core.Enums;

namespace CarrBnk.Financial.Core.Entities
{
    public class FinancialPostings
    {
        public FinancialPostings(string? code, decimal value, FinancialPostingType financialPostingType, string description, DateTime? creationDate)
        {
            Code = code ?? string.Empty;
            Value = value;
            FinancialPostingType = financialPostingType;
            Description = description;
            CreationDate = creationDate;
        }

        public string Code { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public string Description { get; private set; }
        public DateTime? CreationDate { get; private set; }

        public void SetCode(string code)
        {
            Code = code;
        }
    }
}
