using CarrBnk.Financial.Report.Core.Enums;

namespace CarrBnk.Financial.Report.Core.Entities
{
    public class FinancialPostings
    {
        public FinancialPostings(string? code, decimal value, FinancialPostingType financialPostingType, DateTime? creationDate)
        {
            Code = code ?? string.Empty;
            Value = value;
            FinancialPostingType = financialPostingType;
            CreationDate = creationDate;
        }

        public string Code { get; private set; }
        public decimal Value { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public DateTime? CreationDate { get; private set; }

        public decimal GetRealValue()
        {
            if (FinancialPostingType == FinancialPostingType.CashOutFlow) return Value * -1;

            return Value;
        }
        public void SetCode(string code)
        {
            Code = code;
        }
    }
}
