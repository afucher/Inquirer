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
                }
            };
            var input2 = new TestPrompt("name", "message")
            {
                _Render = () =>
                {
                    if(calledInput1)
                        calledInput2 = true;
                }
            };

            var Inquirer = new Inquirer(input1, input2);

            Inquirer.Ask();

            calledInput2.Should().BeTrue();
        }
    }
}
