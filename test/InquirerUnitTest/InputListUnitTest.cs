
using FluentAssertions;
using InquirerCore.Prompts;
using System;
using System.IO;
using Xunit;
using NSubstitute;
using InquirerCore.Console;
using InquirerCore.Validators;

namespace InquirerUnitTest
{
    public class InputListUnitTest
    {
        [Fact]
        public void ShouldHaveNameAndMessage()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new ListInput(name, message, new string[] { }, consoleRender);

            input.message.Should().Be(message);
            input.name.Should().Be(name);
        }

        [Fact]
        public void QuestionShouldReturnMessageAndOptions()
        {
            var message = "Message";
            var name = "Name";
            var options = new string[] { "option1", "option2" };
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new ListInput(name, message, options, consoleRender);

            var question = input.GetQuestion();

            question.Should().HaveCount(3);
            question[0].Should().Be("Message");
        }

        [Fact]
        public void FirstQuestionShouldBeRenderedAsSelected()
        {
            var message = "Message";
            var name = "Name";
            var options = new string[] { "option1", "option2" };
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new ListInput(name, message, options, consoleRender);

            var question = input.GetQuestion();

            question[1].Should().Be("> option1");
        }

        [Fact]
        public void ShouldCallConsoleWriteLine()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new ListInput(name, message, new string[] { "option1", "option2" }, consoleRender);
            input.Render();

            consoleRender.Received().RenderMultipleMessages(Arg.Any<string[]>());
        }

    }
}
