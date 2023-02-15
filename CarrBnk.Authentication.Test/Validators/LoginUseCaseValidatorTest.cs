using AutoBogus;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using CarrBnk.Authentication.Core.UseCase.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace CarrBnk.Authentication.Test.Validators
{
    public class LoginUseCaseValidatorTest
    {
        private readonly LoginUseCaseValidator _validator;
        public LoginUseCaseValidatorTest()
        {
            _validator = new LoginUseCaseValidator();
        }

        [Fact]
        public async Task ShouldBeValid()
        {
            //Arrange

            var model = new AutoFaker<LoginUseCaseRequest>()
                .RuleFor(k => k.UserName, "username")
                .RuleFor(k => k.Password, "password")
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task ShouldHaveErrorWhenUsernameIsEmpty()
        {
            //Arrange

            var model = new AutoFaker<LoginUseCaseRequest>()
                .RuleFor(k => k.UserName, string.Empty)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.UserName);
        }

        [Fact]
        public async Task ShouldHaveErrorWhenPasswordIsEmpty()
        {
            //Arrange

            var model = new AutoFaker<LoginUseCaseRequest>()
                .RuleFor(k => k.Password, string.Empty)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Password);
        }
    }
}
