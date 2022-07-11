using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class BooleanValidatorUnitTest
    {
        [Theory]
        [InlineData("true")]
        [InlineData("True")]
        [InlineData("false")]
        [InlineData("False")]
        [InlineData("TRUE")]
        [InlineData("FALSE")]
        public void ShouldAcceptBooleanValues(string aBooleanValue)
        {
            var validator = new BooleanValidator();

            var isValid = validator.Validate(aBooleanValue);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData(" ")]
        [InlineData("invalid")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotAcceptNonBooleanValues(string aBooleanValue)
        {
            var validator = new BooleanValidator();

            var isValid = validator.Validate(aBooleanValue);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new BooleanValidator();

            validator.GetErrorMessage().Should().Be("Answer accepts only valid boolean values.");
        }
    }
}