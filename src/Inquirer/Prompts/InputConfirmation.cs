using InquirerCore.Validators;

namespace InquirerCore.Prompts
{
    public class InputConfirmation : Input
    {
        public InputConfirmation(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
            SetValid(new RegexValidator(@"^(?:y\b|n\b)"));
        }

        public override string[] GetQuestion()
        {
            return new[] { $"{message} (y/n)" };
        }
    }
}