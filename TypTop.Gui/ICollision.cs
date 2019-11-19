using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TypTop.Gui
{
    interface ICollision : IPosition
    {
        public Rect Boundaries { get; protected set; }


    }
}
