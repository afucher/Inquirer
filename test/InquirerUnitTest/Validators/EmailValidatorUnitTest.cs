using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class EmailValidatorUnitTest
    {
        [Theory]
        [InlineData("email@example.com")]
        [InlineData("firstname.lastname@example.com")]
        [InlineData("email@subdomain.example.com")]
        [InlineData("firstname+lastname@example.com")]
        [InlineData("email@123.123.123.123")]
        [InlineData("email@[123.123.123.123]")]
        [InlineData("\"email\"@example.com")]
        [InlineData("1234567890@example.com")]
        [InlineData("email@example-one.com")]
        [InlineData("_______@example.com")]
        [InlineData("email@example.name")]
        [InlineData("email@example.museum")]
        [InlineData("email@example.co.jp")]
        [InlineData("firstname-lastname@example.com")]
        public void ShouldAcceptValidEmailAddresses(string aValidEmail)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(aValidEmail);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("plainaddress")]
        [InlineData("#@%^%#$@#$@#.com")]
        [InlineData("@example.com")]
        [InlineData("email.example.com")]
        [InlineData("email@example@example.com")]
        [InlineData(".email@example.com")]
        public void ShouldNotAcceptInvalidEmailAddresses(string anInvalidEmail)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(anInvalidEmail);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new EmailValidator();

            validator.GetErrorMessage().Should().Be("Answer accepts only valid Email adresses.");
        }
    }
}
