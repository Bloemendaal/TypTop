using System;

namespace BasicGameEngine
{
    public interface ITimer : IDisposable
    {
        int Interval { get; set; }
    }
}