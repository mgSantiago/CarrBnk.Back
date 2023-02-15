using AutoBogus;
using CarrBnk.Financial.Core.Entities;
using FluentAssertions;
using Xunit;

namespace CarrBnk.Financial.Test.Entities
{
    public class FinancialPostingsTest
    {
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
