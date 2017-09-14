using FluentAssertions;
using InquirerCore;
using InquirerCore.Prompts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InquirerUnitTest
{
    public class InquirerUnitTest
    {
        [Fact]
        public void ShouldInitializeWithQuestions()
        {
            var input1 = new Input("name", "message");
            var input2 = new Input("name", "message");
            var Inquirer = new Inquirer(input1, input2);
            Inquirer.Questions.Should().HaveCount(2);
        }

        [Fact]
        public void ShouldAskQuestionsInOrder()
        {
            var calledInput1 = false;
            var calledInput2 = false;
            var input1 = new TestPrompt("name", "message")
            {
                _Render = () => {
                    calledInput1 = true;
                    calledInput2.Should().BeFalse();
                }
            };
            var input2 = new TestPrompt("name", "message")
            {
                _Render = () =>
                {
                    calledInput2 = true;
                    calledInput1.Should().BeTrue();
                }
            };

            var Inquirer = new Inquirer(input1, input2);

            Inquirer.Ask();

            calledInput1.Should().BeTrue();
            calledInput2.Should().BeTrue();
        }
    }
}
