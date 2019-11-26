using System.Drawing.Printing;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class TextPrintDrawer : IKeyPrintDrawer
    ***REMOVED***
        public HorizontalAlignment HorizontalAlignment ***REMOVED*** get; set; ***REMOVED*** = HorizontalAlignment.Left;
        public VerticalAlignment VerticalAlignment ***REMOVED*** get; set; ***REMOVED***
        public Vector2 Offset ***REMOVED*** get; set; ***REMOVED***

        private KeyStyle _style;
        public string Text ***REMOVED*** get; ***REMOVED***
        
        public KeyStyle Style
        ***REMOVED***
            get => _style;
            set
            ***REMOVED***
                _style = value;
                UpdateFormattedText();
        ***REMOVED***
    ***REMOVED***

        protected FormattedText FormattedText ***REMOVED*** get; private set; ***REMOVED***

        public TextPrintDrawer(string text, KeyStyle style)
        ***REMOVED***
            Text = text;
            Style = style;
    ***REMOVED***

        private void UpdateFormattedText()
        ***REMOVED***
#pragma warning disable 618
            FormattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(Style.Font),
                Style.FontSize,
                Style.SymbolBrush);


    ***REMOVED***

        public virtual void Draw(Rect key, DrawingContext drawingContext)
        ***REMOVED***
            var textRectangle = new Rect
            ***REMOVED***
                Width = FormattedText.WidthIncludingTrailingWhitespace, 
                Height = FormattedText.Height
        ***REMOVED***;

            switch (HorizontalAlignment)
            ***REMOVED***
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
        ***REMOVED***

            switch (VerticalAlignment)
            ***REMOVED***
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
        ***REMOVED***

            textRectangle.X += Offset.X;
            textRectangle.Y += Offset.Y;

            drawingContext.DrawText(FormattedText, textRectangle.Location);
    ***REMOVED***
***REMOVED***
***REMOVED***