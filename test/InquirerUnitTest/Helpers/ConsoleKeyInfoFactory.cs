using System;
using System.Linq;

namespace InquirerUnitTest.Helpers
{
    public class ConsoleKeyInfoFactory
    {
        public ConsoleKeyInfo Get(char key)
        {
            switch (key)
            {
                case 'A':
                    return new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
                case 'B':
                    return new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false);
                case '\n':
                    return new ConsoleKeyInfo((char)13, ConsoleKey.Enter, false, false, false);
                case '\b':
                    return new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false);
                case '¨':
                    return new ConsoleKeyInfo('\0', ConsoleKey.D6, true, false, false);
                case 'ü':
                    return new ConsoleKeyInfo('ü', ConsoleKey.U, false, false, false);
                case '@':
                    return new ConsoleKeyInfo('@', ConsoleKey.D2, false, false, false);
                default:
                    throw new Exception("Not implemented");
            }
        }

        public ConsoleKeyInfo[] GetMultipleLetters(string keys)
        {
            return keys.ToArray().Select(x => Get(x)).ToArray();
        }
    }
}
