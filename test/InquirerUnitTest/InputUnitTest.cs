
using FluentAssertions;
using InquirerCore.Prompts;
using System;
using System.IO;
using System.Linq;
using Xunit;
using NSubstitute;
using InquirerCore.Console;
using InquirerCore.Validators;

namespace InquirerUnitTest
{
    public class InputUnitTest
    {
        [Fact]
        public void ShouldHaveNameAndMessage()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);

            input.message.Should().Be(message);
            input.name.Should().Be(name);
        }

        [Fact]
        public void QuestionShouldReturnOnlyOneString()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);

            var question = input.GetQuestion();

            question.Should().HaveCount(1);
            question[0].Should().Be("Message");
        }

        [Fact]
        public void ShouldCallConsoleWriteLine()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);
            input.Render();

            consoleRender.Received().Render(Arg.Any<string[]>(), Arg.Any<string[]>());
        }


        [Fact]
        public void ShouldAnswerTheFirstResponse()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);
            var answer = "Answer";

            consoleRender.ReadLine().Returns(answer);

            input.Ask();

            input.Answer().Should().Be(answer);

        }

        [Fact]
        public void ShouldCallValid()
        {
            var message = "Message";
            var name = "Name";
            var valid = Substitute.For<IValidator>();
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);
            var answer = "Answer";

            consoleRender.ReadLine().Returns(answer);
            valid.Validate(answer).Returns(true);

            input.SetValid(valid);
            input.Ask();

            valid.Received().Validate(answer);
        }

        [Fact]
        public void ShouldReRenderWhenInvalidAnswer()
        {
            var message = "Message";
            var name = "Name";
            var valid = Substitute.For<IValidator>();
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input(name, message, consoleRender);
            var answer = "Answer";

            consoleRender.ReadLine().Returns(answer);
            consoleRender.Render(Arg.Any<string[]>(), Arg.Any<string[]>()).Returns(new int[2]);
            valid.Validate(answer).Returns(false, true);

            input.SetValid(valid);
            input.Ask();

            consoleRender.Received(2).Render(Arg.Any<string[]>(),Arg.Any<string[]>());
        }

        [Fact]
        public void ShouldShowErrorMessageFromValidator_WhenUserAnswerIsInvalid()
        {
            var errorMessage = "Error message from validator";
            var valid = Substitute.For<IValidator>();
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input("Name", "Message", consoleRender);
            var answer = "Answer";

            consoleRender.ReadLine().Returns(answer);
            consoleRender.Render(Arg.Any<string[]>(), Arg.Any<string[]>()).Returns(new int[2]);
            valid.Validate(answer).Returns(false, true);
            valid.ErrorMessage.Returns(errorMessage);

            input.SetValid(valid);
            input.Ask();

            consoleRender.Received().Render(Arg.Any<string[]>(),Arg.Is<string[]>(messages => messages.Length == 0));
            consoleRender.Received().Render(Arg.Any<string[]>(),Arg.Is<string[]>(messages => messages.SequenceEqual(new []{errorMessage})));
        }

        [Fact]
        public void ShouldEraseNewLineAfterUserAnswerCorrectly()
        {
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new Input("Name", "Message", consoleRender);
            var answer = "Answer";

            consoleRender.ReadLine().Returns(answer);
            consoleRender.Render(Arg.Any<string[]>(), Arg.Any<string[]>()).Returns(new int[2]);
            
            input.Ask();

            Received.InOrder(() =>
            {
                consoleRender.Newline();
                consoleRender.Clean(0,0);
            });

        }

    }
}
