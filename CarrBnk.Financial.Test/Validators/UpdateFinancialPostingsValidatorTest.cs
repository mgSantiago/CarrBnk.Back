using AutoBogus;
using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.Financial.Core.UseCases.Validators;
using FluentValidation.TestHelper;
using System.Text;
using Xunit;

namespace CarrBnk.Financial.Test.Validators
{
    public class UpdateFinancialPostingsValidatorTest
    {
        private readonly UpdateFinancialPostingsValidator _validator;
        public UpdateFinancialPostingsValidatorTest()
        {
            _validator = new UpdateFinancialPostingsValidator();
        }

        [Fact]
        public async Task ShouldBeValid()
        {
            //Arrange

            var code = new StringBuilder(24)
                .Insert(0, "a", 24)
                .ToString();

            var model = new AutoFaker<UpdateFinancialPostingsRequest>()
                .RuleFor(k => k.Code, code)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public async Task ShouldHaveErrorWhenValueIsLessOrEqualToZero(int value)
        {
            //Arrange

            var model = new AutoFaker<UpdateFinancialPostingsRequest>()
                .RuleFor(k => k.Value, value)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public async Task ShouldHaveErrorWhenDescriptionIsNotValid(int size)
        {
            //Arrange

            var description = new StringBuilder(size)
            .Insert(0, "a", size)
            .ToString();

            var model = new AutoFaker<UpdateFinancialPostingsRequest>()
                .RuleFor(k => k.Description, description)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Description);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(23)]
        [InlineData(25)]
        public async Task ShouldHaveErrorWhenCodeIsNotValid(int size)
        {
            //Arrange

            var description = new StringBuilder(size)
            .Insert(0, "a", size)
            .ToString();

            var model = new AutoFaker<UpdateFinancialPostingsRequest>()
                .RuleFor(k => k.Description, description)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Code);
        }
    }
}
