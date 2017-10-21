using Xunit;
using Microsoft.Reactive.Testing;
using FluentAssertions;
using InquirerCore.Console;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace InquirerUnitTest
{
    public class ConsoleObservableUnitTest
    {

        [Fact]
        public void LineObservableShouldReturnStringBeforeEnterKeyPress()
        {
            var line = "";
            var expectedLine = "AB";
            var scheduler = new TestScheduler();
            var console = Substitute.For<IConsole>();
            var consoleObservable = new ConsoleObservable(console, scheduler);
            var keyInfoA = new ConsoleKeyInfo('A', ConsoleKey.A,false, false, false);
            var keyInfoB = new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false);
            var keyInfoEnter = new ConsoleKeyInfo((char)13, ConsoleKey.Enter, false, false, false);
            console.ReadKey(false).Returns(keyInfoA, keyInfoB, keyInfoEnter);

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
            var keyInfoA = new ConsoleKeyInfo('\0', ConsoleKey.D6,true, false, false );
            var keyInfoB = new ConsoleKeyInfo('ü', ConsoleKey.U, false, false, false);
            var keyInfoEnter = new ConsoleKeyInfo((char)13, ConsoleKey.Enter, false, false, false);
            console.ReadKey(false).Returns(keyInfoA, keyInfoB, keyInfoEnter);

            consoleObservable.GetLineObservable().Subscribe(x => line = x);
            scheduler.Start();
            line.Should().Be(expectedLine);
        }

    }
}
