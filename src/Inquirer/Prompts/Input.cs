using System.Collections.Generic;

namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string _answer;
        private bool _isValid = true;
        public Input(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
        }

        public override string Answer()
        {
            return _answer;
        }

        public override void Ask()
        {
            int[] pos = null;
            do
            {
                if(pos != null)
                    consoleRender.Clean(0, pos[0]);

                pos = Render();

                _answer = GetUserAnswer();

                _isValid = IsValidAnswer(_answer);

            } while (!_isValid);
            
            consoleRender.Newline();
            consoleRender.Clean(0,0);
        }
        
        protected virtual string GetUserAnswer()
        {
           return consoleRender.ReadLine();
        }

        public override string[] GetQuestion()
        {
            return new[] { message };
        }

        public override int[] Render()
        {
            var bottomContent = new List<string>();
            if(!_isValid) bottomContent.Add(Validator.GetErrorMessage());
            
            return consoleRender.Render(GetQuestion(), bottomContent.ToArray());
        }
    }
}
