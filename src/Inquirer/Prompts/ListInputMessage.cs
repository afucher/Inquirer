using System;

namespace InquirerCore.Prompts
{
    public class ListInputMessage
    {
        public ListInputMessage(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
        public bool IsSelected { get; private set; }
        public ConsoleColor ConsoleColor => IsSelected ? ConsoleColor.Cyan : ConsoleColor.Gray;
        public void SetSelectedItem(bool selected) 
            => IsSelected = selected;
    }
}

