using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;

namespace InquirerCore.Console
{
    public class ConsoleObservable : IInputObservable
    {
        private readonly IConsole console;
        private IScheduler scheduler;
        private IObservable<ConsoleKeyInfo> input;
        private IEnumerable<ConsoleKeyInfo> ConsoleInput
        {
            get
            {
                while (true)
                {
                    yield return console.ReadKey(false);
                }
            }
        }
        private IEnumerable<ConsoleKeyInfo> ConsoleInputIntercept
        {
            get
            {
                while (true)
                {
                    yield return console.ReadKey(true);
                }
            }
        }
        public ConsoleObservable(IConsole console, IScheduler scheduler = null)
        {
            this.console = console;
            this.scheduler = scheduler ?? CurrentThreadScheduler.Instance;
            input = ConsoleInput.ToObservable(this.scheduler)
                                .Do(ImplementKeysBehaviours)
                                .Publish()
                                .RefCount();
        }

        public IObservable<ConsoleKeyInfo> GetEnterObservable()
        {
            return input.Where(x => x.Key == ConsoleKey.Enter);
        }

        public IObservable<string> GetLineObservable()
        {
            return input.TakeUntil(GetEnterObservable())
                        .Select(x => x.KeyChar.ToString())
                        .Aggregate((x, y) => x + y);
        }

        public IObservable<ConsoleKeyInfo> KeyPress()
        {
            return input;
        }

        private void ImplementKeysBehaviours(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Backspace)
            {
                console.Write(" \b");
            }

            if (key.Key == ConsoleKey.Enter)
            {
                console.CursorTop++;
            }
        }

        public void Intercept(bool intercept)
        {
            var inputToUse = intercept ? ConsoleInputIntercept : ConsoleInput;
            input = inputToUse.ToObservable(scheduler)
                              .Do(ImplementKeysBehaviours)
                              .Publish()
                              .RefCount();
        }
    }
}
