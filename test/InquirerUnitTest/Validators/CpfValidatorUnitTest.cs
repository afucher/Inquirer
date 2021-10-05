using FluentAssertions;
using InquirerCore.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InquirerUnitTest.Validators
{
    public class CpfValidatorUnitTest
    {
        [Theory]
        [InlineData("088.218.720-17")]
        [InlineData("229.709.540-60")]
        [InlineData("22970954060")]
        public void ShouldAcceptCpfValues(string aDateValue)
        {
            var validator = new CpfValidator();

            var isValid = validator.Validate(aDateValue);

            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("22970954060aa")]
        [InlineData("22970954061")]
        [InlineData("229709540/60")]
        [InlineData("invalid")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotAcceptNoCpfValues(string aNonDateValue)
        {
            var validator = new CpfValidator();

            var isValid = validator.Validate(aNonDateValue);

            isValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnErrorMessage()
        {
            var validator = new CpfValidator();

            validator.GetErrorMessage().Should().Be("Answer accepts only CPF's numbers.");
        }
    }
}
