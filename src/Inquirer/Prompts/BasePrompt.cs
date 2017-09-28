using InquirerCore.Console;
using InquirerCore.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Prompts
{
    public abstract class BasePrompt : IPrompt
    {
        public string name { private set; get; }
        public string message { private set; get; }
        protected IValidator Validator;
        protected readonly IScreenManager consoleRender;

        public BasePrompt(string name, string message, IScreenManager consoleRender)
        {
            this.name = name;
            this.message = message;
            this.consoleRender = consoleRender;
        }

        public void SetValid(IValidator validator) => Validator = validator;

        public bool IsValidAnswer(string answer)
        {
            if (Validator == null) return true;

            return Validator.Validate(answer);
        }

        public abstract string[] GetQuestion();
        public abstract int[,] Render();
        public abstract string Answer();
        public abstract void Ask();
    }
}
