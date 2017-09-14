using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Prompts
{
    public abstract class BasePrompt : IPrompt
    {
        public string name { private set; get; }
        public string message { private set; get; }

        public BasePrompt(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

        public abstract string[] GetQuestion();
        public abstract void Render();
        public abstract string Answer();
    }
}
