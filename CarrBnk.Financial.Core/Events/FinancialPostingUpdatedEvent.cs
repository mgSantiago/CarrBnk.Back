using CarrBnk.Financial.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Core.CoreEvents
{
    [ExcludeFromCodeCoverage]
    public record FinancialPostingUpdatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType) { }
}
