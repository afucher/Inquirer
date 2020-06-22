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
            
            Task.Run(() =>
            {
                consoleRender.ReadLine().Returns(aString);
                consoleRender.RenderMultipleMessages(Arg.Any<string[]>()).Returns(new int[2, 2]);

                inputNumber.Ask();
            });
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
            
            inputNumber.Answer().Should().BeEmpty();
        }
        
        [Fact]
        public void ShouldAcceptNegativeValue()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var inputNumber = new InputNumber(name, message, consoleRender);
            var aNegativeNumeric = "-94";
            Task.Run(() =>
            {
                consoleRender.ReadLine().Returns(aNegativeNumeric);
                consoleRender.RenderMultipleMessages(Arg.Any<string[]>()).Returns(new int[2, 2]);

                inputNumber.Ask();
            });
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
            inputNumber.Answer().Should().Be(aNegativeNumeric);


        }
    }
}