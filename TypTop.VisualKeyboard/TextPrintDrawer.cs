using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class TextPrintDrawer : IKeyPrintDrawer
    {
        private KeyStyle _style;
        public string Text { get; }

        public KeyStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                UpdateFormattedText();
            }
        }

        protected FormattedText FormattedText { get; private set; }

        public TextPrintDrawer(string text, KeyStyle style)
        {
            Text = text;
            Style = style;
        }

        private void UpdateFormattedText()
        {
#pragma warning disable 618
            FormattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Myriad"),
                22,
                Style.SymbolBrush);
        }

        public void Draw(Rect key, DrawingContext drawingContext)
        {
            var point = new Point(key.X, key.Y);
            var textLocation = new Point(point.X, point.Y);
            drawingContext.DrawText(FormattedText, textLocation);
        }
    }
}