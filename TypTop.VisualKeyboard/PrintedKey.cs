using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class PrintedKey : KeyboardKey
    ***REMOVED***
        private readonly IKeyPrintDrawer[] _keyPrints;

        public PrintedKey(Key key, Rect rect, KeyStyle style, params IKeyPrintDrawer[] keyPrints) : base(key,rect,style)
        ***REMOVED***
            _keyPrints = keyPrints;
            Style = style;
    ***REMOVED***

        public override void DrawSymbols(DrawingContext drawingContext)
        ***REMOVED***
            foreach (IKeyPrintDrawer keyPrintDrawer in _keyPrints)
            ***REMOVED***
                keyPrintDrawer.Draw(Rectangle, drawingContext);
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***