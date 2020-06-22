using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class NumericValidatorUnitTest
    {
        [Theory]
        [InlineData("0")]
        [InlineData("7846")]
        [InlineData("-8476")]
        [InlineData("8.5")]
        [InlineData("-0.3")]
        public void ShouldAcceptNumericValues(string aNumericValue)
        {
            var validator = new NumericValidator();

            var isValid = validator.Validate(aNumericValue);

            isValid.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("sjdkh")]
        [InlineData("32hjh32")]
        [InlineData("-")]
        public void ShouldNotAcceptNonNumericValues(string aNonNumericValue)
        {
            var validator = new NumericValidator();

            var isValid = validator.Validate(aNonNumericValue);

            isValid.Should().BeFalse();
        }
    }
}