using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class PrintedKey : KeyboardKey
    {
        private readonly IKeyPrintDrawer[] _keyPrints;

        public PrintedKey(Key key, Size size, KeyStyle style, params IKeyPrintDrawer[] keyPrints) : base(key, size,
            style)
        {
            _keyPrints = keyPrints;
            Style = style;
        }

        public override void DrawSymbols(DrawingContext drawingContext)
        {
            foreach (IKeyPrintDrawer keyPrintDrawer in _keyPrints) keyPrintDrawer.Draw(Rectangle, drawingContext);
        }
    }
}