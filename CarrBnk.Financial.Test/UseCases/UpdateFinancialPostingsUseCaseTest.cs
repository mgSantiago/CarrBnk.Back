using AutoBogus;
using CarrBnk.Financial.Core.Entities;
using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases;
using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.RabbitMq.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarrBnk.Financial.Test.UseCases
{
    public class UpdateFinancialPostingsUseCaseTest
    {
        private readonly UpdateFinancialPostingsUseCase _useCase;
        private readonly Mock<IPublisherService> _publisherService;
        private readonly Mock<IFinancialPostingsRepository> _financialPostingRepository;
        private readonly Mock<ILogger<UpdateFinancialPostingsUseCase>> _logger;

        public UpdateFinancialPostingsUseCaseTest()
        {
            _publisherService = new Mock<IPublisherService>();
            _financialPostingRepository = new Mock<IFinancialPostingsRepository>();
            _logger = new Mock<ILogger<UpdateFinancialPostingsUseCase>>();
            _useCase = new UpdateFinancialPostingsUseCase(_financialPostingRepository.Object, _logger.Object, _publisherService.Object);
        }

        [Fact]
        public async Task UpdateFinancialPostingsSucceeded()
        {
            //Arrange

            var request = new AutoFaker<UpdateFinancialPostingsRequest>().Generate();

            var code = Guid.NewGuid().ToString();

            _financialPostingRepository.Setup(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            //Act

            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _publisherService.Verify(k => k.Publish(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _financialPostingRepository.Verify(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateFinancialPostingsError()
        {
            //Arrange

            //Act

            await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.Handle(null, new CancellationToken()));

            //Assert

            _publisherService.Verify(k => k.Publish(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _financialPostingRepository.Verify(k => k.Update(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
