using CarrBnk.Financial.Core.Enums;
using MediatR;

namespace CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Dtos
{
    public class CreateFinancialPostingsRequest : IRequest<bool>
    {
        public decimal Value { get; set; }
        public FinancialPostingType FinancialPostingType { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
