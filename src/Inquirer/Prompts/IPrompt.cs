using InquirerCore.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Prompts
{
    public interface IPrompt
    {
        void Render();
        string[] GetQuestion();
        string Answer();
        void Ask();
        void SetValid(IValidator validator);
        bool IsValidAnswer(string answer);
    }
}
