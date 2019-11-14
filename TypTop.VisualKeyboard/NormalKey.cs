using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class NormalKey : KeyboardKey
    {
        public string Text { get; }
        protected FormattedText FormattedText { get; private set; }

        private KeyStyle _style;

        private void UpdateFormattedText()
        {
#pragma warning disable 618
            FormattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                32,
                Style.SymbolBrush);
        }

        public sealed override KeyStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                UpdateFormattedText();
            }
        }

        public NormalKey(Key key, string text, Point point, KeyStyle style) : base(key,new Rect(point, new Size(50,50)))
        {
            Text = text;
            Style = style;
        }

        public override void DrawSymbols(DrawingContext drawingContext)
        {
            var center = new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            Point textLocation = new Point(center.X - FormattedText.WidthIncludingTrailingWhitespace / 2, center.Y - FormattedText.Height / 2);
            drawingContext.DrawText(FormattedText, textLocation);
        }
    }
}