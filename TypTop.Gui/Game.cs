using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace TypTop.Gui
{
    public abstract class Game
    {
        public readonly DispatcherTimer Timer = new DispatcherTimer();  // timer
        public readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        public Game()
        {
            //  DispatcherTimer setup, ~59 intervals per second, 1000 / 60 = 16.6667... miliseconds
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
            Timer.Start();
        }

        protected abstract void Timer_Tick(object sender, EventArgs e);
    }
}
