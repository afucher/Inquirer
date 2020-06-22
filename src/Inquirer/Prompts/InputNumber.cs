using InquirerCore.Validators;

namespace InquirerCore.Prompts
{
    public class InputNumber : Input
    {
        public InputNumber(string name, string message, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
            SetValid(new NumericValidator());
        }
    }
}