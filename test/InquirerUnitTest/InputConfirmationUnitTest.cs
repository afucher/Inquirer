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

            input.Ask();

            input.Answer().Should().Be(answer);
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
            var askHasFinished = false;

            Task.Run(() =>
            {
                consoleRender.ReadLine().Returns(answer);
                consoleRender.RenderMultipleMessages(Arg.Any<string[]>()).Returns(new int[2, 2]);

                input.Ask();
                askHasFinished = true;
            });
            Task.Delay(TimeSpan.FromMilliseconds(100)).Wait();

            askHasFinished.Should().BeFalse();
        }
    }
}