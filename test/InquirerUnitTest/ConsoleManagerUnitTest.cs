using System;
using FluentAssertions;
using InquirerCore.Console;
using NSubstitute;
using Xunit;

namespace InquirerUnitTest
{
    public class ConsoleManagerUnitTest
    {
        [Fact]
        public void RenderMultipleMessages_ShouldCallWriteLine_ForEachMessage()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            consoleManager.RenderMultipleMessages(new[] {"a", "b", "c"});
            
            console.Received(3).WriteLine(Arg.Any<string>());
        }

        [Fact]
        public void Render_ShouldWriteOnConsole_ForEachMessage()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            consoleManager.Render(new[] {"a", "b", "c"}, new[] {"a", "b", "c"});
            
            console.Received(6).WriteLine(Arg.Any<string>());
        }
        
        [Fact]
        public void Render_ShouldWriteOnConsoleJustContent_WhenBottomContentIsEmpty()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            consoleManager.Render(new[] {"a", "b", "c"}, new string[] { });
            
            console.Received(3).WriteLine(Arg.Any<string>());
        }

        [Fact]
        public void Render_ShouldReturnArrayWithNumberOfLinesWrittenOnConsole()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            var numberOfLines = consoleManager.Render(new[] {"a", "b", "c"}, new[] {"a", "b"});
            
            numberOfLines.ShouldBeEquivalentTo(new [] {3, 2});
        }
        
        [Fact]
        public void Render_ShouldReturnZero_WhenBottomContentIsEmpty()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            var numberOfLines = consoleManager.Render(new[] {"a", "b", "c"}, new string[] {});
            
            numberOfLines.ShouldBeEquivalentTo(new [] {3, 0});
        }
        
        [Fact]
        public void Render_ShouldAddNewLineBetweenContentAndBottomContent()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);

            consoleManager.Render(new[] {"a"}, new[] {"c"});
            
            Received.InOrder(() => {
                console.WriteLine(Arg.Any<string>());
                console.Write(Environment.NewLine);
                console.WriteLine(Arg.Any<string>());
            });
        }
        
        [Fact]
        public void Render_ShouldPlaceConsoleCursorBetweenContents()
        {
            var console = Substitute.For<IConsole>();
            var consoleManager = new ConsoleManager(console);
            console.CursorTop.Returns(7);

            consoleManager.Render(new[] {"a"}, new[] {"c"});

            console.Received().CursorTop = 5;
        }
    }
}