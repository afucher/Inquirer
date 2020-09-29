using FluentAssertions;
using InquirerCore.Validators;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class EmailValidatorUnitTest
    {
        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("fake@yahoo.com")]
        [InlineData("my.name@school.edu")]
        public void ShouldAcceptEmailAddressValues(string anEmailAddress)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(anEmailAddress);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("test email@gmail.com")]
        [InlineData("joe\\@blow@yahoo.com")]
        public void ShouldNotIncludeSpecialCharacterValues(string anEmailAddress)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(anEmailAddress);

            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("my.name@school")]
        public void ShouldEndInValidDomain(string anEmailAddress)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(anEmailAddress);

            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("work.email.address")]
        [InlineData("Email Address")]
        public void ShouldHaveAtSymbolAndPeriod(string anEmailAddress)
        {
            var validator = new EmailValidator();

            var isValid = validator.Validate(anEmailAddress);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new EmailValidator();

            validator.GetErrorMessage().Should().Be("Invalid email address");
        }
    }
}
