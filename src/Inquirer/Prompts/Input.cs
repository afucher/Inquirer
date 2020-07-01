namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string _answer;
        public Input(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
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
           return consoleRender.ReadLine();
        }

        public override string[] GetQuestion()
        {
            return new[] { message };
        }

        public override int[,] Render()
        {
            return consoleRender.RenderMultipleMessages(GetQuestion());
        }
    }
}
