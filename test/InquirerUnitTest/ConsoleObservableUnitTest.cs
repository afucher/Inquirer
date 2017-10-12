
using FluentAssertions;
using InquirerCore.Prompts;
using System;
using System.IO;
using Xunit;
using NSubstitute;
using InquirerCore.Console;
using InquirerCore.Validators;

namespace InquirerUnitTest
{
    public class ConsoleObservableUnitTest
    {
        [Fact]
        public void ShouldHaveNameAndMessage()
        {
            /*var console = Substitute.For<IConsole>();
            var observer = Substitute.For<IObserver<ConsoleKeyInfo>>();
            var observable = new ConsoleObservable(console);
            
            var enter = observable.GetEnterObservable();
            var a = new ConsoleKeyInfo(new char(), ConsoleKey.Enter, false, false, false);
            console.ReadKey().Returns(a);
            enter.Subscribe(observer);
            observer.Received().OnNext(Arg.Any<ConsoleKeyInfo>());*/

        }

    }
}
