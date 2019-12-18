using System;

namespace TypTop.GameEngine
{
    class GameTimer : ITimed, ITimer
    {
        public int Interval { get; set; }
        private readonly Action _callback;
        private double _passedMilliseconds;
        private bool _disposed;

        public GameTimer(Action callback, int interval)
        {
            Interval = interval;
            _callback = callback;
        }

        /// <summary>
        /// 
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

        public void Dispose()
        {
            _disposed = true;
        }
    }
}