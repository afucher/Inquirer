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
            int[,] pos = null;

            do
            {
                if(pos != null)
                    consoleRender.Clean(pos[0, 1], pos[1, 1]);
                pos = Render();
                _answer = "";
                _answer = consoleRender.ReadLine();
                
            } while (!IsValidAnswer(_answer));
            
            consoleRender.Newline();
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
