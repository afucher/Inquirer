using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace InquirerCore.Console
{
    public class ConsoleObservable : IInputObservable
    {
        private readonly IConsole console;
        private IObservable<ConsoleKeyInfo> input;
        private IEnumerable<ConsoleKeyInfo> ConsoleInput
        {
            get
            {
                while (true)
                {
                    yield return console.ReadKey();
                }
            }
        }
        public ConsoleObservable(IConsole console)
        {
            this.console = console;
            input = ConsoleInput.ToObservable()
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
    }
}
