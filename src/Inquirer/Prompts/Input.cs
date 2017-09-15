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
        public Input(string name, string message, IConsole console = null) : base(name, message, console)
        {
        }

        public override string Answer()
        {
            return answer;
        }

        public override string[] GetQuestion()
        {
            return new string[] { message };
        }

        public override void Render()
        {
            GetQuestion().ToList().ForEach(line => Console.WriteLine(line));
            answer = Console.ReadLine();
        }
    }
}
