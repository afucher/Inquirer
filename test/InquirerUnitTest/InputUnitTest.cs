
using FluentAssertions;
using Inquirer.Prompts;
using System;
using System.IO;
using Xunit;

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
        public void ShouldAskTheQuestion()
        {
            var message = "Message";
            var name = "Name";
            var input = new Input(name, message);
            var expected = message + Environment.NewLine;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                input.Render();

                sw.ToString().Should().Be(expected);
            }
        }

        [Fact]
        public void ShouldAnswerTheFirstResponse()
        {

        }
    }
}
