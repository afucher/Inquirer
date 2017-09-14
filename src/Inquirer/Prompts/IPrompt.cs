using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Prompts
{
    interface IPrompt
    {
        void Render();
        string[] GetQuestion();
    }
}
