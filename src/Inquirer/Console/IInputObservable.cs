using System;

namespace InquirerCore.Console
{
    public interface IInputObservable
    {
        IObservable<ConsoleKeyInfo> GetEnterObservable();
        IObservable<ConsoleKeyInfo> KeyPress();
        IObservable<string> GetLineObservable();
    }
}