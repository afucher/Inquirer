using System;
using System.Threading.Tasks;
using FluentAssertions;
using InquirerCore.Prompts;
using NSubstitute;
using Xunit;

namespace InquirerUnitTest
{
    public class InputConfirmationUnitTest
    {
        [Fact]
        public void ShouldAddYesOrNoOptionToQuestion()
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new InputConfirmation(name, message, consoleRender);

            var question = input.GetQuestion();

            question.Should().BeEquivalentTo("Message (y/n)");
        }

        [Theory]
        [InlineData("y")]
        [InlineData("n")]
        public void ShouldAccept_y_And_n_AsAnswer(string answer)
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new InputConfirmation(name, message, consoleRender);

            consoleRender.ReadLine().Returns(answer);

            var isValid = input.IsValidAnswer(answer);

            isValid.Should().BeTrue();
        }
        
        
        [Theory]
        [InlineData("yy")]
        [InlineData("nn")]
        [InlineData("ydw")]
        [InlineData("ndskjd")]
        [InlineData("a")]
        [InlineData("389746237")]
        [InlineData("")]
        public void ShouldNotAcceptAnythingDifferentThan_y_Or_n_AsAnswer(string answer)
        {
            var message = "Message";
            var name = "Name";
            var consoleRender = Substitute.For<IScreenManager>();
            var input = new InputConfirmation(name, message, consoleRender);

            var isValid = input.IsValidAnswer(answer);

            isValid.Should().BeFalse();
        }
    }
}