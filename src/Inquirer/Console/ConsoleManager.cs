using System;
using System.Drawing;
using System.Linq;
using InquirerCore.Prompts;

namespace InquirerCore.Console
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

        public int[] Render(string[] content, string[] bottomContent)
        {
            content.ToList().ForEach(message => console.WriteLine(message));
            Newline();
            bottomContent.ToList().ForEach(message => console.WriteLine(message));
            console.CursorTop = console.CursorTop - (bottomContent.Length + 1);
            return new [] { content.Length, bottomContent.Length };
        }

        public int[] RenderList(ListInputMessage[] content, string[] bottomContent)
        {
            content.ToList().ForEach(item => {
                console.ForegroundColor = item.ConsoleColor;
                console.WriteLine(item.Message);
            });
            Newline();
            console.ResetColor();
            bottomContent.ToList().ForEach(message => console.WriteLine(message));
            console.CursorTop = console.CursorTop - (bottomContent.Length + 1);
            return new[] { content.Length, bottomContent.Length };
        }

        public void Clean(int initialPos, int endPos)
        {
            console.CursorLeft = 0;
            console.Write(new string(' ', console.WindowWidth-1));
            for (var lineNumbers= endPos - initialPos; lineNumbers > 0; lineNumbers--)
            {
                if (console.CursorTop == 0) break;

                console.CursorTop--; 
                console.CursorLeft = 0;
                console.Write(new string(' ', console.WindowWidth-1));
            }
            console.CursorLeft = 0;
        }

        public int[,] RenderMultipleMessages(string[] mensagens)
        {
            var pos = new int[2,2];
            pos[0,0] = console.CursorLeft;
            pos[0,1] = console.CursorTop;
            mensagens.ToList().ForEach(mensagem => console.WriteLine(mensagem));
            pos[1, 0] = console.CursorLeft;
            pos[1, 1] = pos[0,1] + mensagens.Length;
            return pos;
        }

        public string ReadLine()
        {
            var line = "";
            
            var subscriber = observable.GetLineObservable().Subscribe(x => line = x);

            return line;
        }

        public IInputObservable GetInputObservable()
        {
            return observable;
        }

        public void Newline()
        {
            console.Write(Environment.NewLine);
        }
    }
}
