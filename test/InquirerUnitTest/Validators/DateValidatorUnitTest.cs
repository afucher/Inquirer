using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class DateValidatorUnitTest
    {
        [Theory]
        [InlineData("2020-01-01")]
        [InlineData("2020-12-31")]
        [InlineData("01-01-2020")]
        [InlineData("05-12-2019")]
        [InlineData("10/05/1999")]
        public void ShouldAcceptDateValues(string aDateValue)
        {
            var validator = new DateValidator();

            var isValid = validator.Validate(aDateValue);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("2020-13-01")]
        [InlineData("-0020-12-01")]
        [InlineData("2020-12-32")]
        [InlineData("invalid")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotAcceptNonDateValues(string aNonDateValue)
        {
            var validator = new DateValidator();

            var isValid = validator.Validate(aNonDateValue);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new DateValidator();

            validator.ErrorMessage.Should().Be("Answer accepts only dates.");
        }
    }
}