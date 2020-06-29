using System;
using System.Text;

namespace InquirerCore.Prompts
{
    public class PasswordInput : BasePrompt
    {
        private string _answer;
        public PasswordInput(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
        }

        public override string[] GetQuestion()
        {
            return new string[] { message };
        }

        public override string Answer()
        {
            return _answer;
        }

        public override void Ask()
        {
            var pos = Render();
            var answer = new StringBuilder();
            var input = consoleRender.GetInputObservable();
            input.Intercept(true);
            input.TakeUntilEnter()
                .Subscribe(x =>
                {
                    answer.Append(x.KeyChar);
                    System.Console.Write('*');
                }, () =>
                {
                    _answer = answer.ToString();
                });
            consoleRender.Newline();
        }

        public override int[,] Render()
        {
            return consoleRender.RenderMultipleMessages(GetQuestion());
        }
    }
}