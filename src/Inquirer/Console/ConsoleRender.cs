using InquirerCore.Console;
using System.Linq;

namespace InquirerCore.Prompts
{
    public class ConsoleRender : IRender
    {
        private readonly IConsole console;

        public ConsoleRender(IConsole console)
        {
            this.console = console;
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
    }
}
