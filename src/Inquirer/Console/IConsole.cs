using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Console
{
    public interface IConsole
    {
        void WriteLine(string value);
        void Write(string value);
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);
        int CursorLeft { get; set; }
        int CursorTop { get; set; }
        int WindowWidth { get; set; }
    }
}
