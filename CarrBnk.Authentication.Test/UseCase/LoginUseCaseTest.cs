using AutoBogus;
using CarrBnk.Authentication.Core.Entities;
using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Core.Ports.Services;
using CarrBnk.Authentication.Core.UseCase;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarrBnk.Authentication.Test.UseCase
{
    public class LoginUseCaseTest
    {
        private readonly LoginUseCase _useCase;

        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<IUserRepository> _repository;
        private readonly Mock<ILogger<LoginUseCase>> _logger;

        public LoginUseCaseTest()
        {
            _tokenService = new Mock<ITokenService>();
            _repository = new Mock<IUserRepository>();
            _logger = new Mock<ILogger<LoginUseCase>>();
            _useCase = new LoginUseCase(_tokenService.Object, _repository.Object, _logger.Object);
        }

        [Fact]
        public async Task LoginSucceeded()
        {
            //Arrange

            var request = new LoginUseCaseRequest("login", "senha");

            var user = new AutoFaker<User>().Generate();

            _repository.Setup(k => k.Get("login", "senha"))
                .ReturnsAsync(user);

            //Act

            var result = await _useCase.Handle(request, new CancellationToken());

            //Assert

            _repository.Verify(k => k.Get(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            result.Username.Should().Be(user.Username);
            result.Token.Should().NotBeEmpty();
        }

        [Fact]
        public async Task LoginNullReferenceException()
        {
            //Arrange

            //Act

            await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.Handle(null, new CancellationToken()));

            //Assert

            _repository.Verify(k => k.Get(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
