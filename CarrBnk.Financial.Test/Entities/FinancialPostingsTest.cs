using AutoBogus;
using CarrBnk.Financial.Core.Entities;
using FluentAssertions;
using Xunit;

namespace CarrBnk.Financial.Test.Entities
{
    public class FinancialPostingsTest
    {
        [Fact]
        public async Task ShouldSetCode()
        {
            //Arrange

            var code = "code_test";

            var financialPostings = new AutoFaker<FinancialPostings>().Generate();

            //Act

            financialPostings.SetCode(code);

            //Assert

            financialPostings.Code.Should().Be(code);
        }
    }
}
