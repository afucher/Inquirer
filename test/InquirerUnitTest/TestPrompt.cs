using InquirerCore.Prompts;
using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerUnitTest
{
    class TestPrompt : BasePrompt
    {
        public Func<string> _Answer;
        public Func<string[]> _GetQuestion;
        public Action _Render;

        public TestPrompt(string name, string message) : base(name, message)
        {
        }

        public override string Answer()
        {
            if (_Answer != null)
                return _Answer.Invoke();
            return "";
        }
        

        public override string[] GetQuestion()
        {
            if (_GetQuestion != null)
                return _GetQuestion.Invoke();
            return new string[] { };
        }

        public override void Render()
        {
            if (_Render != null)
                _Render.Invoke();
        }
    }
}
