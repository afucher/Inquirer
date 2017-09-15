
using FluentAssertions;
using InquirerCore.Prompts;
using System;
using System.IO;
using Xunit;
using NSubstitute;
using InquirerCore.Console;

namespace InquirerUnitTest
{
    public class InputUnitTest
    {
        [Fact]
        public void ShouldHaveNameAndMessage()
        {
            var message = "Message";
            var name = "Name";
            var input = new Input(name, message);

            input.message.Should().Be(message);
            input.name.Should().Be(name);
        }

        [Fact]
        public void QuestionShouldReturnOnlyOneString()
        {
            var message = "Message";
            var name = "Name";
            var input = new Input(name, message);

            var question = input.GetQuestion();

            question.Should().HaveCount(1);
            question[0].Should().Be("Message");
        }

        [Fact]
        public void ShouldCallConsoleWriteLine(){
            var message = "Message";
            var name = "Name";
            var console = Substitute.For<IConsole>();
            var input = new Input(name, message, console);
            input.Render();

            console.Received().WriteLine(message);
        }


        [Fact]
        public void ShouldAnswerTheFirstResponse()
        {
            var message = "Message";
            var name = "Name";
            var console = Substitute.For<IConsole>();
            var input = new Input(name, message, console);
            var answer = "Answer";

            console.ReadLine().Returns(answer);

            input.Render();

            input.Answer().Should().Be(answer);

        }

        [Fact]
        public void ShouldNotFailWhenQuestionHaveMoreThanOneLine(){
            var message = "First Line" + Environment.NewLine + "Second Line";
            var name = "Name";
            var input = new Input(name, message);
            var expected = message + Environment.NewLine;
            var answer = "Answer" + Environment.NewLine;
            var expectedAnswer = "Answer";

            using (StringWriter sw = new StringWriter())
            using (StringReader sr = new StringReader(answer))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);
                input.Render();

                sw.ToString().Should().Be(expected);
                input.Answer().Should().Be(expectedAnswer);
            }
        }
    }
}
