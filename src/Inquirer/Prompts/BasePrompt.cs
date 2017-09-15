using InquirerCore.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Prompts
{
    public abstract class BasePrompt : IPrompt
    {
        public string name { private set; get; }
        public string message { private set; get; }
        protected IConsole Console;

        public BasePrompt(string name, string message, IConsole console = null)
        {
            this.name = name;
            this.message = message;
            this.Console = console ?? new ConsoleWrapper();
        }

        public abstract string[] GetQuestion();
        public abstract void Render();
        public abstract string Answer();
    }
}
