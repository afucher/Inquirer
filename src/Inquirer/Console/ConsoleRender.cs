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

        public void RenderMultipleMessages(string[] mensagens)
        {
            mensagens.ToList().ForEach(mensagem => console.WriteLine(mensagem));
            
        }
    }
}
