using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class BlankKey : KeyboardKey
    {
        public BlankKey(Key key, Size size, KeyStyle style) : base(key, size, style)
        {
        }

        public override void DrawSymbols(DrawingContext drawingContext)
        {
            //Do nothing
        }
    }
}