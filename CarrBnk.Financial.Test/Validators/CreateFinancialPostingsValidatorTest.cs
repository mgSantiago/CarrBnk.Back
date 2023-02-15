using AutoBogus;
using CarrBnk.Financial.Core.UseCases.Dtos;
using CarrBnk.Financial.Core.UseCases.Validators;
using FluentValidation.TestHelper;
using System.Drawing;
using System.Text;
using Xunit;

namespace CarrBnk.Financial.Test.Validators
{
    public class CreateFinancialPostingsValidatorTest
    {
        private readonly CreateFinancialPostingsValidator _validator;
        public CreateFinancialPostingsValidatorTest()
        {
            _validator = new CreateFinancialPostingsValidator();
        }

        [Fact]
        public async Task ShouldBeValid()
        {
            //Arrange
            
            var model = new AutoFaker<CreateFinancialPostingsRequest>().Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task ShouldHaveErrorWhenValueIsZero()
        {
            //Arrange

            var model = new AutoFaker<CreateFinancialPostingsRequest>()
                .RuleFor(k => k.Value, 0)
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

            var model = new AutoFaker<CreateFinancialPostingsRequest>()
                .RuleFor(k => k.Description, string.Empty)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Description);
        }
    }
}
