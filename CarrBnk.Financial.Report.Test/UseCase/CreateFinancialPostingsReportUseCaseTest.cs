using AutoBogus;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarrBnk.Financial.Test.UseCases
{
    public class CreateFinancialPostingsReportUseCaseTest
    {
        private readonly CreateFinancialPostingsReportUseCase _useCase;
        private readonly Mock<IFinancialReportRepository> _financialReportRepository;
        private readonly Mock<ILogger<CreateFinancialPostingsReportUseCase>> _logger;

        public CreateFinancialPostingsReportUseCaseTest()
        {
            _financialReportRepository = new Mock<IFinancialReportRepository>();
            _logger = new Mock<ILogger<CreateFinancialPostingsReportUseCase>>();
            _useCase = new CreateFinancialPostingsReportUseCase(_financialReportRepository.Object, _logger.Object);
        }

        [Fact]
        public async Task CreateFinancialPostingsSucceeded()
        {
            //Arrange

            var request = new AutoFaker<CreateFinancialPostingsRequest>().Generate();

            var code = Guid.NewGuid().ToString();

            _financialReportRepository.Setup(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()))
                .Returns((FinancialPostings financialPostings, CancellationToken cancellationToken) =>
                {
                    financialPostings.SetCode(code);
                    return Task.CompletedTask;
                });

            //Act

            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _financialReportRepository.Verify(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().Be(code);
        }

        [Fact]
        public async Task CreateFinancialPostingsNullReferenceException()
        {
            //Arrange

            //Act

            await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.Handle(null, new CancellationToken()));

            //Assert

            _financialReportRepository.Verify(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
