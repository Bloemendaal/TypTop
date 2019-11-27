using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.Gui
{
    interface IGravity : IPosition
    {
        public double FallAcceleration { get; set; }

        public double Mass { get; set; }
    }
}
