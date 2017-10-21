using Xunit;
using Microsoft.Reactive.Testing;
using FluentAssertions;
using InquirerCore.Console;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using InquirerUnitTest.Helpers;
using System.Linq;

namespace InquirerUnitTest
{
    public class ConsoleObservableUnitTest
    {
        private ConsoleKeyInfoFactory ckiFactory = new ConsoleKeyInfoFactory();
        [Fact]
        public void LineObservableShouldReturnStringBeforeEnterKeyPress()
        {
            var line = "";
            var expectedLine = "AB";
            var scheduler = new TestScheduler();
            var console = Substitute.For<IConsole>();
            var consoleObservable = new ConsoleObservable(console, scheduler);
            var keys = ckiFactory.GetMultipleLetters("AB\n");

            console.ReadKey(Arg.Any<bool>()).Returns(keys.First(), keys.Skip(1).ToArray() );

            consoleObservable.GetLineObservable().Subscribe(x => line = x);
            scheduler.Start();
            line.Should().Be(expectedLine);
        }

        [Fact]
        public void LineObservableShouldWorkWithShift()
        {
            var line = "";
            var expectedLine = "ü";
            var scheduler = new TestScheduler();
            var console = Substitute.For<IConsole>();
            var consoleObservable = new ConsoleObservable(console, scheduler);
            var keys = ckiFactory.GetMultipleLetters("¨ü\n");

            console.ReadKey(Arg.Any<bool>()).Returns(keys.First(), keys.Skip(1).ToArray() );

            consoleObservable.GetLineObservable().Subscribe(x => line = x);
            scheduler.Start();
            line.Should().Be(expectedLine);
        }

    }
}
