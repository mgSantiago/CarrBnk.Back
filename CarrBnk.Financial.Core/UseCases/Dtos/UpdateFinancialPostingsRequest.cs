using CarrBnk.Financial.Core.Enums;
using MediatR;

namespace CarrBnk.Financial.Core.UseCases.Dtos
{
    public class UpdateFinancialPostingsRequest : IRequest<bool>
    {
        public string Code { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public FinancialPostingType FinancialPostingType { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
