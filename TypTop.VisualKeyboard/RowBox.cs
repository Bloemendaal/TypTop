using System;
using System.Windows;

namespace TypTop.VisualKeyboard
{
    public class RowBox
    {
        private double _rowHeight;
        private double _x;
        private double _y;

        public double Spacing { get; set; } = 5;

        public void NextRow()
        {
            _y += _rowHeight + Spacing;
            _x = 0;
        }

        public Point GetPosition(Size box)
        {
            _rowHeight = Math.Max(box.Height, _rowHeight);
            var x = _x;
            _x += box.Width + Spacing;
            return new Point(x, _y);
        }
    }
}