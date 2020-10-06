using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class FullNameValidatorUnitTest
    {
        [Theory]
        [InlineData("Joe Doe")]
        [InlineData("Liz Bianca Fátima Lima")]
        [InlineData("Stephany")]
        [InlineData("Charlie Muntz")]
        [InlineData("Muhammad Ali")]
        public void ShouldAcceptValidNames(string aValidName)
        {
            var validator = new FullNameValidator();

            var isValid = validator.Validate(aValidName);

            isValid.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("123213")]
        [InlineData("!#!#!#")]
        [InlineData("aa")]
        public void ShouldNotAcceptInvalidNames(string aInvalidName)
        {
            var validator = new FullNameValidator();

            var isValid = validator.Validate(aInvalidName);

            isValid.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new FullNameValidator();

            validator.GetErrorMessage().Should().Be("Name must be valid.");
        }
    }
}