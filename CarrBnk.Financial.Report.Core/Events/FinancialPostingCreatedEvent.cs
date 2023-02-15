using CarrBnk.Financial.Report.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Report.Core.CoreEvents
{
    [ExcludeFromCodeCoverage]
    public record FinancialPostingCreatedEvent(string Code, decimal Value, FinancialPostingType FinancialPostingType, DateTime CreationDate) { }
}
