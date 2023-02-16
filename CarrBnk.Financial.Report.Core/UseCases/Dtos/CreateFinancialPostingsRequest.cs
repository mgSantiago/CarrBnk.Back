using CarrBnk.Financial.Report.Core.Constants.Enums;
using MediatR;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    public class CreateFinancialPostingsRequest : IRequest<string>
    {
        public CreateFinancialPostingsRequest(string code, FinancialPostingType financialPostingType, decimal value)
        {
            Code = code;
            FinancialPostingType = financialPostingType;
            Value = value;
        }

        public string Code { get; set; }
        public FinancialPostingType FinancialPostingType { get; set; }
        public decimal Value { get; set; }
    }
}
