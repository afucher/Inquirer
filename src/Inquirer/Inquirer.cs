using InquirerCore.Prompts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InquirerCore
{
    public class Inquirer
    {
        public List<BasePrompt> Questions { get; private set; }
        public Inquirer(params BasePrompt[] questions)
        {
            Questions = questions.ToList<BasePrompt>();
        }

        public void Ask()
        {
            Questions.ForEach((q) => q.Render());
        }
    }
}
