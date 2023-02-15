using CarrBnk.Financial.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Core.CoreEvents
{
    [ExcludeFromCodeCoverage]
    public record FinancialPostingCreatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType, DateTime CreationDate) { }
}
