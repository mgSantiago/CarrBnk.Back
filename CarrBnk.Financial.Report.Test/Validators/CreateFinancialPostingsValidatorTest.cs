using AutoBogus;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Financial.Report.Core.UseCases.Validators;
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

            var code = new StringBuilder(24)
                .Insert(0, "a", 24)
                .ToString();

            var model = new AutoFaker<CreateFinancialPostingsRequest>()
                .RuleFor(k => k.Code, code)
                .Generate();

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
        [InlineData("")]
        [InlineData(null)]
        [InlineData("63ee5e511153a20c30af943")]
        [InlineData("63ee5e511153a20c30af94355")]
        public async Task ShouldHaveErrorWhenCodeIsInvalid(string code)
        {
            //Arrange

            var model = new AutoFaker<CreateFinancialPostingsRequest>()
                .RuleFor(k => k.Code, code)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Code);
        }
    }
}
