using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class PrintedKey : KeyboardKey
    {
        private readonly IKeyPrintDrawer[] _keyPrints;

        public PrintedKey(Key key, Rect rect, KeyStyle style, params IKeyPrintDrawer[] keyPrints) : base(key,rect,style)
        {
            _keyPrints = keyPrints;
            Style = style;
        }

        public override void DrawSymbols(DrawingContext drawingContext)
        {
            foreach (IKeyPrintDrawer keyPrintDrawer in _keyPrints)
            {
                keyPrintDrawer.Draw(Rectangle, drawingContext);
            }
        }
    }
}