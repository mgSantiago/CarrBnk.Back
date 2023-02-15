using AutoBogus;
using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using CarrBnk.Financial.Report.Core.UseCases.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace CarrBnk.Financial.Report.Test.Validators
{
    public class GetFinancialDailyReportValidatorTest
    {
        private readonly GetFinancialDailyReportValidator _validator;
        public GetFinancialDailyReportValidatorTest()
        {
            _validator = new GetFinancialDailyReportValidator();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-60)]
        [InlineData(-1440)]
        public void ShouldBeValid(int minutes)
        {
            //Arrange

            var model = new AutoFaker<GetFinancialDailyReportRequest>()
                .RuleFor(k => k.Date, DateTime.Now.AddMinutes(minutes))
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(60)]
        [InlineData(1440)]
        public void ShouldHaveErrorWhenDateIsFuture(int minutes)
        {
            //Arrange

            var model = new AutoFaker<GetFinancialDailyReportRequest>()
                .RuleFor(k => k.Date, DateTime.Now.AddMinutes(minutes))
                .Generate();

            //Act

            var result = _validator.TestValidate(model);

            //Assert

            result.ShouldHaveValidationErrorFor(k => k.Date);
        }
    }
}
