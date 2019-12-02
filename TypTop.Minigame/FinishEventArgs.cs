using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine
{
    public class FinishEventArgs : EventArgs
    {
        public int? Lives;
        public int? Score;
        public int? Count;

        public int Stars = 0;
    }
}
