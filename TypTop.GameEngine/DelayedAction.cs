using System;
using System.Threading;

namespace BasicGameEngine
{
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