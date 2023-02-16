using AutoBogus;
using CarrBnk.Financial.Report.Core.Constants.Enums;
using CarrBnk.Financial.Report.Core.Entities;
using FluentAssertions;
using Xunit;

namespace CarrBnk.Financial.Report.Test.Entities
{
    public class FinancialPostingsTest
    {
        [Theory]
        [InlineData(FinancialPostingType.CashInFlow, 5)]
        [InlineData(FinancialPostingType.CashOutFlow, -5)]
        public async Task ShouldBeValid(FinancialPostingType financialPostingType, int expectedRealValue)
        {
            //Arrange

            var financialPostings = new AutoFaker<FinancialPostings>()
                .RuleFor(k => k.FinancialPostingType, financialPostingType)
                .RuleFor(k => k.Value, 5)
                .Generate();

            //Act

            var realValue = financialPostings.GetRealValue();

            //Assert

            realValue.Should().Be(expectedRealValue);
        }

        [Theory]
        [InlineData("code_test")]
        [InlineData(null)]
        public async Task ShouldSetCode(string code)
        {
            //Arrange

            var financialPostings = new AutoFaker<FinancialPostings>().Generate();

            //Act

            financialPostings.SetCode(code);

            //Assert

            financialPostings.Code.Should().Be(code);
        }
    }
}
