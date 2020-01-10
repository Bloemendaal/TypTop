using System;
using System.Threading;

namespace TypTop.GameEngine
{
    /// <summary>
    ///   <para>Used for executing delayed actions in the game</para>
    /// </summary>
    /// <seealso cref="TypTop.GameEngine.ITimed" />
    internal class DelayedAction : ITimed
    {
        private double _passedMilliseconds;
        private readonly Action _callback;
        private readonly int _millisecondsDelay;
        private readonly CancellationToken _cancellationToken;

        public DelayedAction(Action callback, int millisecondsDelay, CancellationToken cancellationToken)
        {
            _callback = callback;
            _millisecondsDelay = millisecondsDelay;
            _cancellationToken = cancellationToken;
        }

        public bool IncrementTime(double deltaTime)
        {
            if (_cancellationToken.IsCancellationRequested)
                return true;

            _passedMilliseconds += deltaTime * 1000;
            if (_passedMilliseconds > _millisecondsDelay)
            {
                _callback();
                return true;
            }
            return false;
        }
    }
}