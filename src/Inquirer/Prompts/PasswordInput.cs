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
            //Create variable for position
            int[,] pos = null;
            //Validation loop
            do
            {
                //Clean console
                if(pos != null)
                    consoleRender.Clean(pos[0, 1], pos[1, 1]);
                //Render question
                pos = Render();
                //Get user answer  !!!!
                _answer = GetUserAnswer();
                
            } while (!IsValidAnswer(_answer));
            
            //Add new line
            consoleRender.Newline();
        }

        private string GetUserAnswer()
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

        public override int[,] Render()
        {
            return consoleRender.RenderMultipleMessages(GetQuestion());
        }
    }
}