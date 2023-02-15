using CarrBnk.Financial.Core.Enums;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Core.UseCases.Dtos
{
    [ExcludeFromCodeCoverage]
    public class CreateFinancialPostingsRequest : IRequest<string>
    {
        public decimal Value { get; set; }
        public FinancialPostingType FinancialPostingType { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
