using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.Gui
{
    interface IPosition
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        public double DragCoefficient { get; set; }

        void UpdateVelocity();

    }
}
