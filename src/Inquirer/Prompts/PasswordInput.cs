using System;
using System.Text;

namespace InquirerCore.Prompts
{
    public class PasswordInput : Input
    {
        public PasswordInput(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
        }

        protected override string GetUserAnswer()
        {
            var answer = new StringBuilder();
            var input = consoleRender.GetInputObservable();
            input.Intercept(true);
            input.TakeUntilEnter()
                .Subscribe(x =>
                {
                    answer.Append(x.KeyChar);
                    System.Console.Write('*');
                });

            return answer.ToString();
        }
    }
}