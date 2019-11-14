using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class NormalKey : KeyboardKey
    ***REMOVED***
        public string Text ***REMOVED*** get; ***REMOVED***
        protected FormattedText FormattedText ***REMOVED*** get; private set; ***REMOVED***

        private KeyStyle _style;

        private void UpdateFormattedText()
        ***REMOVED***
#pragma warning disable 618
            FormattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                32,
                Style.SymbolBrush);
    ***REMOVED***

        public sealed override KeyStyle Style
        ***REMOVED***
            get => _style;
            set
            ***REMOVED***
                _style = value;
                UpdateFormattedText();
        ***REMOVED***
    ***REMOVED***

        public NormalKey(Key key, string text, Point point, KeyStyle style) : base(key,new Rect(point, new Size(50,50)))
        ***REMOVED***
            Text = text;
            Style = style;
    ***REMOVED***

        public override void DrawSymbols(DrawingContext drawingContext)
        ***REMOVED***
            var center = new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            Point textLocation = new Point(center.X - FormattedText.WidthIncludingTrailingWhitespace / 2, center.Y - FormattedText.Height / 2);
            drawingContext.DrawText(FormattedText, textLocation);
    ***REMOVED***
***REMOVED***
***REMOVED***