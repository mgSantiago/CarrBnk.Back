using AutoBogus;
using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Core.UseCases;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Redis.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarrBnk.Financial.Test.UseCases
{
    public class UpdateFinancialPostingsUseCaseTest
    {
        private readonly UpdateFinancialDailyReportUseCase _useCase;
        private readonly Mock<IFinancialReportRepository> _financialPostingRepository;
        private readonly Mock<ILogger<UpdateFinancialDailyReportUseCase>> _logger;
        private readonly Mock<ICacheService> _cacheService;

        public UpdateFinancialPostingsUseCaseTest()
        {
            _financialPostingRepository = new Mock<IFinancialReportRepository>();
            _logger = new Mock<ILogger<UpdateFinancialDailyReportUseCase>>();
            _cacheService = new Mock<ICacheService>();
            _useCase = new UpdateFinancialDailyReportUseCase(_financialPostingRepository.Object, _logger.Object, _cacheService.Object);
        }

        [Fact]
        public async Task UpdateFinancialPostingsSucceeded()
        {
            //Arrange

            var request = new AutoFaker<UpdateFinancialDailyReportRequest>().Generate();

            var code = Guid.NewGuid().ToString();

            _financialPostingRepository.Setup(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            //Act

            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _financialPostingRepository.Verify(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateFinancialPostingsNullReferenceException()
        {
            //Arrange

            //Act

            await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.Handle(null, new CancellationToken()));

            //Assert

            _financialPostingRepository.Verify(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
