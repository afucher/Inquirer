using System;
using System.Linq;

namespace InquirerCore.Console
{
    public static class ConsoleUtils
    {
        //Made this private since it is only used in this class
        private static ConsoleKey[] DigitsKeys = new ConsoleKey[]{ ConsoleKey.D0,
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
