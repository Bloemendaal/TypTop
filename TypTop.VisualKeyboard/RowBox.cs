***REMOVED***
using System.Windows;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class RowBox
    ***REMOVED***
        private double _x;
        private double _y;

        private double _rowHeight;

        public double Spacing ***REMOVED*** get; set; ***REMOVED*** = 5;

        public void NextRow()
        ***REMOVED***
            _y += _rowHeight + Spacing;
            _x = 0;
    ***REMOVED***

        public Point GetPosition(Size box)
        ***REMOVED***
            _rowHeight = Math.Max(box.Height, _rowHeight);
            double x = _x;
            _x += box.Width + Spacing;
            return new Point(x, _y);
    ***REMOVED***
***REMOVED***
***REMOVED***