using CarrBnk.Financial.Core.Enums;

namespace CarrBnk.Financial.Core.CoreEvents
{
    public record FinancialPostingUpdatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType) { }
}
