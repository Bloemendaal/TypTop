using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class TextPrintDrawer : IKeyPrintDrawer
    ***REMOVED***
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
                new Typeface("Myriad"),
                22,
                Style.SymbolBrush);
    ***REMOVED***

        public void Draw(Rect key, DrawingContext drawingContext)
        ***REMOVED***
            var point = new Point(key.X, key.Y);
            var textLocation = new Point(point.X, point.Y);
            drawingContext.DrawText(FormattedText, textLocation);
    ***REMOVED***
***REMOVED***
***REMOVED***