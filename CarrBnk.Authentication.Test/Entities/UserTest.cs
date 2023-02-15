using AutoBogus;
using CarrBnk.Authentication.Core.Entities;
using FluentAssertions;
using Xunit;

namespace CarrBnk.Authentication.Test.Entities
{
    public class UserTest
    {
        [Fact]
        public void ShouldBeEquivalent()
        {
            //Arrange

            var generatedUser = new AutoFaker<User>().Generate();

            //Act
            var userToValidate = new User(generatedUser.Id, generatedUser.Username, generatedUser.Password, generatedUser.Role);

            //Assert

            userToValidate.Should().BeEquivalentTo(generatedUser);
        }
    }
}
