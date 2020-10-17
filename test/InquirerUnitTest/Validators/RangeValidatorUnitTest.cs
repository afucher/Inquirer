using FluentAssertions;
using InquirerCore.Validators;
using Xunit;
using System;


namespace InquirerUnitTest.Validators
{
    public class RangeValidatorUnitTest
    {
        public const int lowerRange = 0, upperRange = 10;

        [Theory]
        [InlineData("0")]
        [InlineData("5")]
        [InlineData("10")]
        public void ShouldInRange(string aNumericValue)
        {
            var validator = new RangeValidator(lowerRange, upperRange);

            var isValid = validator.Validate(aNumericValue);

            isValid.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("-1")]
        [InlineData("sjdkh")]
        [InlineData("32hjh32")]
        [InlineData("-")]
        public void ShouldOutRange(string aNonNumericValue)
        {
            var validator = new RangeValidator(lowerRange, upperRange);

            var isValid = validator.Validate(aNonNumericValue);

            isValid.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new RangeValidator(lowerRange, upperRange);

            validator.ErrorMessage.Should().Be("Answer accepts between 0 to 10.");
        }
    }
}