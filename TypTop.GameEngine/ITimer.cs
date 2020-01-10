using System;

namespace TypTop.GameEngine
{

    /// <summary>Returned by timed actions. The Dispose method is used for stopping the timer</summary>
    /// <seealso cref="System.IDisposable" />
    public interface ITimer : IDisposable
    {
        /// <summary>
        ///   <para>
        ///  Controls the interval of the timer.
        /// </para>
        /// </summary>
        /// <value>The interval.</value>
        int Interval { get; set; }
    }
}