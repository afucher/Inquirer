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
        private readonly IConsole console;
        private ConsoleObservable observable;

        public ConsoleManager(IConsole console = null)
        {
            this.console = console ?? new ConsoleWrapper();
            observable = new ConsoleObservable(this.console);
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
            
            var subscriber = observable.GetLineObservable().Subscribe(x => line = x);

            return line;
        }

        public IObservable<ConsoleKeyInfo> KeyPress()
        {
            return observable.KeyPress();
        }

        public IInputObservable getInputObservable()
        {
            return observable;
        }
    }
}
