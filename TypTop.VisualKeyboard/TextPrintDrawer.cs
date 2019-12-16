using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class TextPrintDrawer : IKeyPrintDrawer
    {
        private KeyStyle _style;

        public TextPrintDrawer(string text, KeyStyle style)
        {
            Text = text;
            Style = style;
        }

        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;
        public VerticalAlignment VerticalAlignment { get; set; }
        public Vector2 Offset { get; set; }
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

        public virtual void Draw(Rect key, DrawingContext drawingContext)
        {
            var textRectangle = new Rect
            {
                Width = FormattedText.WidthIncludingTrailingWhitespace,
                Height = FormattedText.Height
            };

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    textRectangle.X = key.X + key.Width / 2 - textRectangle.Width / 2;
                    break;
                case HorizontalAlignment.Left:
                    textRectangle.X = key.X;
                    break;
                case HorizontalAlignment.Right:
                    textRectangle.X = key.X + key.Width - textRectangle.Width;
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Center:
                case VerticalAlignment.Stretch:
                    textRectangle.Y = key.Y + key.Height / 2 - textRectangle.Height / 2;
                    break;
                case VerticalAlignment.Top:
                    textRectangle.Y = key.Y;
                    break;
                case VerticalAlignment.Bottom:
                    textRectangle.Y = key.Y + key.Height - textRectangle.Height;
                    break;
            }

            textRectangle.X += Offset.X;
            textRectangle.Y += Offset.Y;

            drawingContext.DrawText(FormattedText, textRectangle.Location);
        }

        private void UpdateFormattedText()
        {
#pragma warning disable 618
            FormattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(Style.Font),
                Style.FontSize,
                Style.SymbolBrush);
        }
    }
}