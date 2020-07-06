using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class RegexValidatorUnitTest
    {
        [Fact]
        public void ShouldReturnTrue_WhenRegexPatternMatch()
        {
            var validator = new RegexValidator(".");

            var isValid = validator.Validate("qualquercoisa");

            isValid.Should().BeTrue();
        }
        
        [Fact]
        public void ShouldReturnFalse_WhenRegexPatternNotMatch()
        {
            var validator = new RegexValidator("[a]");

            var isValid = validator.Validate("bbbb");

            isValid.Should().BeFalse();
        }
        
    }
}