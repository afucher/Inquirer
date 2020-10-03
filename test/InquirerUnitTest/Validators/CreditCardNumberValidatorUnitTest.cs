using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest
{
    public class CreditCardNumberValidatorUnitTest
    {
        [Theory]
        [InlineData("1111-2222-3333-4444")]
        [InlineData("1111 2222 3333 4444")]
        [InlineData("1111222233334444")]
        [InlineData("1234567890123456")]

        public void ShouldAcceptValidCreditCard(string validCreditCard)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(validCreditCard);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("111a-2222-3333-4444")]
        [InlineData("1111/2222 3333 4444")]
        [InlineData("11112123123123123123123122233334444")]
        [InlineData("2131")]
        [InlineData("213@1")]
        [InlineData("123456789012345'")]
        [InlineData("asdfghjkl;qwerty")]
        public void ShouldNotAcceptInvalidCreditCard(string validCreditCard)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(validCreditCard);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new CreditCardNumberValidator();

            validator.GetErrorMessage().Should().Be("Answer accepts only valid 16 digits credit cards.");
        }
    }
}