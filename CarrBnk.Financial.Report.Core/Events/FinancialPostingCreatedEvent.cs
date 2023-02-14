using CarrBnk.Financial.Report.Core.Enums;

namespace CarrBnk.Financial.Report.Core.CoreEvents
{
    public record FinancialPostingCreatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType, DateTime CreationDate) { }
}
