using InquirerCore.Console;
using System;

namespace InquirerCore.Prompts
{
    public interface IScreenManager
    {
        int[,] RenderMultipleMessages(string[] mensagens);
        void Clean(int initialPos, int endPos);
        string ReadLine();
        IInputObservable GetInputObservable();
    }
}