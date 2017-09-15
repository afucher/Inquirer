﻿using FluentAssertions;
using InquirerCore;
using InquirerCore.Prompts;
using NSubstitute;
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
            var input01 = Substitute.For<IPrompt>();
            var input02 = Substitute.For<IPrompt>();

            input01.When(x => x.Render())
                    .Do(x => calledInput1 = true);
            input02.When(x => x.Render())
                    .Do(x => { if (calledInput1) calledInput2 = true; });


            var Inquirer = new Inquirer(input01, input02);

            Inquirer.Ask();

            calledInput2.Should().BeTrue();
        }
    }
}
