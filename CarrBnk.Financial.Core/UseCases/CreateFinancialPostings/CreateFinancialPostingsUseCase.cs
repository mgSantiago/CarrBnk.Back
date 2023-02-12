using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Dtos;
using Core.Entities;
using MediatR;

namespace CarrBnk.Financial.Core.UseCases.CreateFinancialPostings
{
    public class CreateFinancialPostingsUseCase : IRequestHandler<CreateFinancialPostingsRequest, string>
    {
        private readonly IFinancialPostingsRepository _repository;

        public CreateFinancialPostingsUseCase(IFinancialPostingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateFinancialPostingsRequest request, CancellationToken cancellationToken)
        {
            var financialPosting = new FinancialPostings(null, request.Value, request.FinancialPostingType, request.Description, DateTime.UtcNow);

            var code = await _repository.Insert(financialPosting);

            return code;
        }
    }
}
