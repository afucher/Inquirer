using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inquirer.Prompts
{
    public class Input : BasePrompt
    {
        private string answer;
        public Input(string name, string message) : base(name, message)
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
