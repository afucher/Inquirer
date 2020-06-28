using System;
using System.IO;
using System.Reactive.Linq;
using FluentAssertions;
using InquirerCore.Console;
using InquirerCore.Prompts;
using InquirerUnitTest.Helpers;
using NSubstitute;
using Xunit;

namespace InquirerUnitTest
{
    public class PasswordInputTest
    {
        private ConsoleKeyInfoFactory ckiFactory = new ConsoleKeyInfoFactory();
        [Fact]
        public void AnswerShouldContainUserInput()
        {
            var consoleRender = Substitute.For<IScreenManager>();
            var inputObservable = Substitute.For<IInputObservable>();
            var userInput = ckiFactory.GetMultipleLetters("AB").ToObservable();
            inputObservable.TakeUntilEnter().Returns(userInput);
            consoleRender.GetInputObservable().Returns(inputObservable);
            var input = new PasswordInput( "Name", "Message", consoleRender);
            
            input.Ask();

            input.Answer().Should().Be("AB");
        }
        
        [Fact]
        public void ConsoleOutputShouldBeOnlyAsterisk()
        {
            using var consoleOutput = new StringWriter();
            var oldOutput = Console.Out;
            Console.SetOut(consoleOutput);
            var consoleRender = Substitute.For<IScreenManager>();
            var inputObservable = Substitute.For<IInputObservable>();
            ConsoleKeyInfo[] keys = ckiFactory.GetMultipleLetters("AB");
            
            inputObservable.TakeUntilEnter().Returns(keys.ToObservable());
            consoleRender.GetInputObservable().Returns(inputObservable);
            var input = new PasswordInput("Name", "Message", consoleRender);
            
            input.Ask();
            
            consoleOutput.ToString().Should().Be("**");
            Console.SetOut(oldOutput);
        }
    }
}