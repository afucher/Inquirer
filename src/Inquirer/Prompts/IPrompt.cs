using System;
using System.Collections.Generic;
using System.Text;

namespace Inquirer.Prompts
{
    interface IPrompt
    {
        void Render();
        string[] GetQuestion();
    }
}
