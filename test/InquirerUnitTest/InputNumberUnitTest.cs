using System;
using System.Threading.Tasks;
using FluentAssertions;
using InquirerCore.Prompts;
using NSubstitute;
using Xunit;

namespace InquirerUnitTest
{
    public class InputNumberUnitTest
    {
        [Fact]
        public void ShouldNotAcceptAlphaValue()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var inputNumber = new InputNumber(name, message, consoleRender);
            var aString = "Answer";
            
            var valid = inputNumber.IsValidAnswer(aString);

            valid.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldAcceptNegativeValue()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var inputNumber = new InputNumber(name, message, consoleRender);
            var aNegativeNumeric = "-94";
           
            var valid = inputNumber.IsValidAnswer(aNegativeNumeric);

            valid.Should().BeTrue();
        }
    }
}