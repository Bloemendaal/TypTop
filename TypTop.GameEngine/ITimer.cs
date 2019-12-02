using System;

namespace TypTop.GameEngine
{
    public interface ITimer : IDisposable
    {
        int Interval { get; set; }
    }
}