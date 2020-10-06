using System;
using System.ComponentModel.Design;
using InquirerCore.Console;

namespace InquirerCore.Prompts
{
    public interface IScreenManager
    {
        int[,] RenderMultipleMessages(string[] messages);
        int[] Render(string[] content, string[] bottomContent);
        int[] Render(ConsoleMessage[] content, ConsoleMessage[] bottomContent);
        void Clean(int initialPos, int endPos);
        string ReadLine();
        IInputObservable GetInputObservable();
        void Newline();
    }
}