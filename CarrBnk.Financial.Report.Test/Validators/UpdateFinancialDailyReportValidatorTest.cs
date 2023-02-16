using AutoBogus;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Financial.Report.Core.UseCases.Validators;
using FluentValidation.TestHelper;
using System.Text;
using Xunit;

namespace CarrBnk.Financial.Test.Validators
{
    public class UpdateFinancialDailyReportValidatorTest
    {
        private readonly UpdateFinancialDailyReportValidator _validator;
        public UpdateFinancialDailyReportValidatorTest()
        {
            _validator = new UpdateFinancialDailyReportValidator();
        }

        [Fact]
        public async Task ShouldBeValid()
        {
            //Arrange

            var code = new StringBuilder(24)
                .Insert(0, "a", 24)
                .ToString();

            var model = new AutoFaker<UpdateFinancialDailyReportRequest>()
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

            var model = new AutoFaker<UpdateFinancialDailyReportRequest>()
                .RuleFor(k => k.Value, value)
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
        public async Task ShouldHaveErrorWhenCodeIsNotValid(string code)
        {
            //Arrange

            var model = new AutoFaker<UpdateFinancialDailyReportRequest>()
                .RuleFor(k => k.Code, code)
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Code);
        }
    }
}
