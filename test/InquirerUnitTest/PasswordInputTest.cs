using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using FluentAssertions;
using InquirerCore.Console;
using InquirerCore.Prompts;
using InquirerCore.Validators;
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
        
        [Fact]
        public void ShouldCallValid()
        {
            var validator = Substitute.For<IValidator>();
            validator.Validate(Arg.Any<string>()).Returns(true);
            var consoleRender = Substitute.For<IScreenManager>();
            var inputObservable = Substitute.For<IInputObservable>();
            ConsoleKeyInfo[] keys = ckiFactory.GetMultipleLetters("AB");
            
            inputObservable.TakeUntilEnter().Returns(keys.ToObservable());
            consoleRender.GetInputObservable().Returns(inputObservable);
            var input = new PasswordInput("Name", "Message", consoleRender);
            input.SetValid(validator);
            
            input.Ask();

            validator.Received().Validate("AB");
        }
        
        [Fact]
        public void AnswerShouldContainsOnlyValidOne()
        {
            var validator = Substitute.For<IValidator>();
            validator.Validate("A").Returns(false);
            validator.Validate("B").Returns(true);
            var consoleRender = Substitute.For<IScreenManager>();
            var inputObservable = Substitute.For<IInputObservable>();
            ConsoleKeyInfo[] keys = ckiFactory.GetMultipleLetters("A");
            consoleRender.RenderMultipleMessages(Arg.Any<string[]>()).Returns(new int[2,2]);
            inputObservable.TakeUntilEnter().Returns(keys.ToObservable(), ckiFactory.GetMultipleLetters("B").ToObservable());
            consoleRender.GetInputObservable().Returns(inputObservable);
            var input = new PasswordInput("Name", "Message", consoleRender);
            input.SetValid(validator);
            
            input.Ask();

            input.Answer().Should().Be("B");
        }
        
        [Fact]
        public void ShouldCallClean_WhenAnswerIsWrong()
        {
            var validator = Substitute.For<IValidator>();
            validator.Validate("A").Returns(false);
            validator.Validate("B").Returns(true);
            var consoleRender = Substitute.For<IScreenManager>();
            var inputObservable = Substitute.For<IInputObservable>();
            ConsoleKeyInfo[] keys = ckiFactory.GetMultipleLetters("A");
            
            inputObservable.TakeUntilEnter().Returns(keys.ToObservable(), ckiFactory.GetMultipleLetters("B").ToObservable());
            consoleRender.GetInputObservable().Returns(inputObservable);
            consoleRender.RenderMultipleMessages(Arg.Is<string[]>(
                    m => m.SequenceEqual(new[] {"Message"})))
                .Returns(new[,] {{1, 2}, {3, 4}});
            var input = new PasswordInput("Name", "Message", consoleRender);
            input.SetValid(validator);
            
            input.Ask();

            consoleRender.Received().Clean(2, 4);
        }
    }
}