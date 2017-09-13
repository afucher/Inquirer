using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inquirer.Prompts
{
    public class Input : BasePrompt
    {
        public Input(string name, string message) : base(name, message)
        {
        }

        public override string Answer()
        {
            throw new NotImplementedException();
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
