namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string answer;
        public Input(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
        }

        public override string Answer()
        {
            return answer;
        }

        public override void Ask()
        {
            var pos = Render();
            answer = consoleRender.ReadLine();
            while (!IsValidAnswer(answer))
            {
                answer = "";
                consoleRender.Clean(pos[0, 1], pos[1, 1]);
                Render();
                answer = consoleRender.ReadLine();
            }
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
