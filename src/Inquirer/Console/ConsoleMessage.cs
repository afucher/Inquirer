using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Console
{
    public class ConsoleMessage
    {
        public ConsoleMessage(string message)
        {
            Message = message;
        }

        public ConsoleMessage(string message, ConsoleColor consoleColor)
        {
            Message = message;
            ConsoleColor = consoleColor;
        }

        public string Message { get; private set; }

        public ConsoleColor? ConsoleColor { get; private set; }

        public void SetMessage(string message)
            => Message = message;

        public void SetConsoleColor(ConsoleColor consoleColor)
            => ConsoleColor = consoleColor;
    }
}
