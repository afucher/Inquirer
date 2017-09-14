using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Console
{
    interface IConsole
    {
        void WriteLine(string value);
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);
    }
}
