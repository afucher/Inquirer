using InquirerCore.Console;

namespace InquirerCore.Prompts
{
    public interface IScreenManager
    {
        int[,] RenderMultipleMessages(string[] mensagens);
        void Clean(int initialPos, int endPos);
        string ReadLine();
        IInputObservable GetInputObservable();
        void Newline();
    }
}