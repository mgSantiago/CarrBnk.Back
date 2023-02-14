using AutoBogus;
using AutoMapper;
using Bogus;
using CarrBnk.Financial.Core.Entities;
using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Core.UseCases;
using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.RabbitMq.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace CarrBnk.Financial.Test.UseCases
{
    public class CreateFinancialPostingsUseCaseTest
    {
        private readonly CreateFinancialPostingsUseCase _useCase;
        private readonly Mock<IPublisherService> _publisherService;
        private readonly Mock<IFinancialPostingsRepository> _financialPostingRepository;
        private readonly Mock<ILogger<CreateFinancialPostingsUseCase>> _logger;

        public CreateFinancialPostingsUseCaseTest()
        {
            _publisherService = new Mock<IPublisherService>();
            _financialPostingRepository = new Mock<IFinancialPostingsRepository>();
            _logger = new Mock<ILogger<CreateFinancialPostingsUseCase>>();
            _useCase = new CreateFinancialPostingsUseCase(_financialPostingRepository.Object, _logger.Object, _publisherService.Object);
        }

        [Fact]
        public async Task CreateFinancialPostingsSucceeded()
        {
            //Arrange
            var request = new AutoFaker<CreateFinancialPostingsRequest>().Generate();

            var code = Guid.NewGuid().ToString();

            _financialPostingRepository.Setup(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()))
                .Returns((FinancialPostings financialPostings, CancellationToken cancellationToken) =>
                {
                    financialPostings.SetCode(code);
                    return Task.CompletedTask;
                });

            //Act
            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _publisherService.Verify(k => k.Publish(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _financialPostingRepository.Verify(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().Be(code);
        }

        [Fact]
        public async Task CreateFinancialPostingsError()
        {
            //Arrange

            //Act
            await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.Handle(null, new CancellationToken()));

            //Assert

            _publisherService.Verify(k => k.Publish(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _financialPostingRepository.Verify(k => k.Insert(It.IsAny<FinancialPostings>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
