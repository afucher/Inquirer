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
                        .Where(IsNormalKeyOrAtCharacter)
                        .Aggregate("", BuildLine);
        }

        public IObservable<ConsoleKeyInfo> TakeUntilEnter()
        {
            return input.TakeUntil(GetEnterObservable());
        }

        private string BuildLine(string content, ConsoleKeyInfo newKey)
        {
            if (newKey.Key == ConsoleKey.Backspace)
                return content == "" ? content : content.Remove(content.Length-1);
            
            return content + newKey.KeyChar;
        }

        public IObservable<ConsoleKeyInfo> KeyPress()
        {
            return input;
        }

        public bool IsNormalKey(ConsoleKeyInfo key)
        {
            var hasShift = key.Modifiers.HasFlag(ConsoleModifiers.Shift);
            if (!hasShift) return true;

            return !ConsoleUtils.isDigit(key.Key);
        }

        /// <summary>
        /// Validate if the key entered is a normal key or the @ character
        /// </summary>
        /// <param name="key">The current key entered</param>
        /// <returns>A boolean representing whether the key entered is a normal key or the @ character</returns>
        public bool IsNormalKeyOrAtCharacter(ConsoleKeyInfo key)
        {
            var hasShift = key.Modifiers.HasFlag(ConsoleModifiers.Shift);
            if (!hasShift) return true;

            return !ConsoleUtils.isDigit(key.Key) || key.Key == ConsoleKey.D2;
        }

        private void ImplementKeysBehaviours(ConsoleKeyInfo cki)
        {
            var key = cki.Key;
            switch (key)
            {
                case ConsoleKey.Backspace:
                    console.Write(" \b");
                    break;
            };
            var hasShift = cki.Modifiers.HasFlag(ConsoleModifiers.Shift);


            //Update Oct 1, 2020
            //If the digit is D2 (@ special character) then it will go back one character and the next will replace it
            //Adding a condition to avoid this and include the @ special character
            if (hasShift && ConsoleUtils.isDigit(key) && (key != ConsoleKey.D2)) console.Write("\b");
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
