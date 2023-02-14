using CarrBnk.Financial.Report.Core.Enums;

namespace CarrBnk.Financial.Report.Core.CoreEvents
{
    public record FinancialPostingUpdatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType) { }
}
