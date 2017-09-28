using System;

namespace InquirerCore.Console
{
    public interface IInputObservable
    {
        IObservable<ConsoleKeyInfo> GetEnterObservable();
        IObservable<string> GetLineObservable();
    }
}