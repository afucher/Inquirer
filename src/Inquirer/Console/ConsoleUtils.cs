using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InquirerCore.Console
{
    public static class ConsoleUtils
    {
        public static ConsoleKey[] DigitsKeys = new ConsoleKey[]{ ConsoleKey.D0,
                                                                ConsoleKey.D1,
                                                                ConsoleKey.D2,
                                                                ConsoleKey.D3,
                                                                ConsoleKey.D4,
                                                                ConsoleKey.D5,
                                                                ConsoleKey.D6,
                                                                ConsoleKey.D7,
                                                                ConsoleKey.D8,
                                                                ConsoleKey.D9 };
        public static bool isDigit(ConsoleKey key)
        {
            return DigitsKeys.Contains(key);
        }
    }
}
