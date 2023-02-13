using CarrBnk.Financial.Core.Enums;

namespace CarrBnk.Financial.Core.CoreEvents
{
    public record FinancialPostingCreatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType, DateTime CreationDate) { }
}
