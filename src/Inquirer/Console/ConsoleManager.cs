using InquirerCore.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace InquirerCore.Prompts
{
    public class ConsoleManager : IScreenManager
    {
        static IEnumerable<ConsoleKeyInfo> ConsoleInput
        {
            get
            {
                while (true)
                {
                    yield return System.Console.ReadKey();
                }
            }
        }
        private readonly IConsole console;

        public ConsoleManager(IConsole console = null)
        {
            this.console = console ?? new ConsoleWrapper();
        }

        public void Clean(int initialPos, int endPos)
        {
            for(var pos = initialPos; pos <= endPos; pos++)
            {
                console.CursorTop = pos;
                console.CursorLeft = 0;
                console.Write(new string(' ', console.WindowWidth));
            }
            console.CursorTop = initialPos;
            console.CursorLeft = 0;
        }

        public int[,] RenderMultipleMessages(string[] mensagens)
        {
            var pos = new int[2,2];
            pos[0,0] = console.CursorLeft;
            pos[0,1] = console.CursorTop;
            mensagens.ToList().ForEach(mensagem => console.WriteLine(mensagem));
            pos[1, 0] = console.CursorLeft;
            pos[1, 1] = console.CursorTop;
            return pos;
        }

        public string ReadLine()
        {
            var line = "";

            var input = ConsoleInput.ToObservable();

            var keyObservable = input
                .Do(TrataKey);
            var EnterObservable = keyObservable.Where(x => x.Key == ConsoleKey.Enter);
            //.TakeWhile(x => x.Key != ConsoleKey.Enter)
            var lineObservable = keyObservable
                .TakeWhile(x => x.Key != ConsoleKey.Enter)
                .Select(x => x.KeyChar.ToString())
                .Aggregate((x, y) => x + y);


            var subscriber = lineObservable.Subscribe(x => line = x);

            return line;
        }

        private void TrataKey(ConsoleKeyInfo key)
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
