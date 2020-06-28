using System;

namespace InquirerCore.Console
{
    public interface IInputObservable
    {
        IObservable<ConsoleKeyInfo> GetEnterObservable();
        IObservable<ConsoleKeyInfo> TakeUntilEnter();
        IObservable<ConsoleKeyInfo> KeyPress();
        IObservable<string> GetLineObservable();
        void Intercept(bool intercept);
    }
}