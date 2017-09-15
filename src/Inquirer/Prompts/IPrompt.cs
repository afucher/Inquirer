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
    }
}
