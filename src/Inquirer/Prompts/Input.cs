using InquirerCore.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string answer;
        public Input(string name, string message, IRender consoleRender, IConsole console = null) : base(name, message, consoleRender, console)
        {
        }

        public override string Answer()
        {
            return answer;
        }

        public override void Ask()
        {
            consoleRender.RenderMultipleMessages(GetQuestion());
            answer = Console.ReadLine();
            while(!(Validator == null || Validator.Validate(answer))){
                consoleRender.RenderMultipleMessages(GetQuestion());
                answer = Console.ReadLine();
            }
        }

        public override string[] GetQuestion()
        {
            return new string[] { message };
        }

        public override void Render()
        {
            GetQuestion().ToList().ForEach(line => Console.WriteLine(line));
        }
    }
}
