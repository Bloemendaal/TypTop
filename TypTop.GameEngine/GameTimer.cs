using System;

namespace TypTop.GameEngine
{
    internal class GameTimer : ITimed, ITimer
    {
        private readonly Action _callback;
        private bool _disposed;
        private double _passedMilliseconds;

        public GameTimer(Action callback, int interval)
        {
            Interval = interval;
            _callback = callback;
        }

        /// <summary>
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns>True if timer is done</returns>
        public bool IncrementTime(double deltaTime)
        {
            if (_disposed)
                return true;

            _passedMilliseconds += deltaTime * 1000;
            if (_passedMilliseconds > Interval)
            {
                _callback();
                _passedMilliseconds = 0;
            }

            return false;
        }

        public int Interval { get; set; }

        public void Dispose()
        {
            _disposed = true;
        }
    }
}