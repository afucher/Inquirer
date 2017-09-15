using InquirerCore.Prompts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InquirerCore
{
    public class Inquirer
    {
        public List<IPrompt> Questions { get; private set; }
        public Inquirer(params IPrompt[] questions)
        {
            Questions = questions.ToList<IPrompt>();
        }

        public void Ask()
        {
            Questions.ForEach((q) => q.Render());
        }
    }
}
