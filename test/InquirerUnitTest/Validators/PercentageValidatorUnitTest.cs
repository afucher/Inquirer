using System;
using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class PercentageValidatorUnitTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("50")]
        [InlineData("75%")]
        [InlineData("100")]
        [InlineData("0.01")]
        [InlineData("0")]
        public void ShouldAcceptValuesBetween0And100(string aPercentValue)
        {
            var validator = new PercentageValidator();

            var isValid = validator.Validate(aPercentValue);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("100.01")]
        [InlineData("5000%")]
        [InlineData("-1")]
        [InlineData("abc")]
        [InlineData("1sdw!")]
        [InlineData("-")]
        public void ShouldNotAcceptValuesUnder0OrHigherThan100(string aNonPercentValue)
        {
            var validator = new PercentageValidator();

            var isValid = validator.Validate(aNonPercentValue);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new PercentageValidator();

            validator.GetErrorMessage().Should().Be("A percentage must be a number between 0 and 100");
        }
    }
}
