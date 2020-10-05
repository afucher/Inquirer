using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class CreditCardNumberValidatorUnitTest
    {
        [Theory]
        [InlineData("4929 9222 5630 0976")]
        [InlineData("4929-9222-5630-0976")]
        [InlineData("4929922256300976")]
        [InlineData("4556737586899855")]
        [InlineData("5522277758452967")]
        [InlineData("4614173898370866")]
        [InlineData("5345422286958722")]
        [InlineData("343850055763282")]
        [InlineData("345964336736377")]
        [InlineData("343540876891665")]
        [InlineData("343850055763282")]
        [InlineData("6304364589469402")]
        [InlineData("36452061374162")]
        public void ShouldAcceptValidCreditCard(string creditCardNumber)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(creditCardNumber);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("11112123123123123123123122233334444")]
        [InlineData("12345678901234567890")]
        [InlineData("1234567")]
        [InlineData("2131")]
        [InlineData("")]
        [InlineData("1")]
        public void ShouldNotAcceptInvalidSize(string creditCardNumber)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(creditCardNumber);

            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("213@1")]
        [InlineData("asdfghjkl;qwerty")]
        [InlineData("111a-2222-3333-4444")]
        [InlineData("1111/2222 3333 4444")]
        [InlineData("123456789012345'")]
        public void ShouldNotAcceptInvalidChars(string creditCardNumber)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(creditCardNumber);

            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("1111 2222 3333 4443")]
        [InlineData("1111-2222-3333-4443")]
        [InlineData("1111222233334443")]
        [InlineData("4073587143326857")]
        public void ShouldNotAcceptInvalidLuhnCheck(string validCreditCard)
        {
            var validator = new CreditCardNumberValidator();

            var isValid = validator.Validate(validCreditCard);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new CreditCardNumberValidator();

            validator.GetErrorMessage().Should().Be("Answer accepts only valid credit cards numbers.");
        }
    }
}