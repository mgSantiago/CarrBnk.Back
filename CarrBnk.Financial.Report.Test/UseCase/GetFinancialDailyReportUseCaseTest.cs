using AutoBogus;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Enums;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarrBnk.Financial.Report.Test.UseCase
{
    public class GetFinancialDailyReportUseCaseTest
    {
        private readonly GetFinancialDailyReportUseCase _useCase;

        private readonly Mock<IFinancialReportRepository> _repository;
        private readonly Mock<ILogger<GetFinancialDailyReportUseCase>> _logger;

        public GetFinancialDailyReportUseCaseTest()
        {
            _repository = new Mock<IFinancialReportRepository>();
            _logger = new Mock<ILogger<GetFinancialDailyReportUseCase>>();
            _useCase = new GetFinancialDailyReportUseCase(_repository.Object, _logger.Object);
        }

        [Theory]
        [InlineData(10.0, 5.0, 15.0)]
        [InlineData(5.0, 2.0, 8.0)]
        [InlineData(2.0, 1.0, 3.0)]
        public async Task CreateFinancialPostingsSucceeded(decimal inFlowValue, decimal outFlowValue, decimal expectedResult)
        {
            //Arrange

            var request = new AutoFaker<GetFinancialDailyReportRequest>().Generate();
            var financialPostings = new AutoFaker<FinancialPostings>()
                .RuleFor(k => k.Value, inFlowValue)
                .RuleFor(k => k.FinancialPostingType, FinancialPostingType.CashInFlow)
                .Generate(2);

            financialPostings.Add(new AutoFaker<FinancialPostings>()
                    .RuleFor(k => k.Value, outFlowValue)
                    .RuleFor(k => k.FinancialPostingType, FinancialPostingType.CashOutFlow)
                    .Generate()
                );

            var code = Guid.NewGuid().ToString();

            _repository.Setup(k => k.GetDailyFinancialMovements(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(financialPostings);

            //Act

            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _repository.Verify(k => k.GetDailyFinancialMovements(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<CancellationToken>()), Times.Once);
            result.DailyConsolidation.Should().Be(expectedResult);
            result.CashInFlowMovementsCount.Should().Be(2);
            result.CashOutFlowMovementsCount.Should().Be(1);
            result.TotalMovements.Should().Be(3);
        }
    }
}
