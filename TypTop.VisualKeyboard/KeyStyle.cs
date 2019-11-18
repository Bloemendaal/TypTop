using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyStyle
    ***REMOVED***
        public Brush BaseBrush ***REMOVED*** get; set; ***REMOVED***
        public Brush FaceBrush ***REMOVED*** get; set; ***REMOVED***
        public Brush SymbolBrush ***REMOVED*** get; set; ***REMOVED***
        public string Font ***REMOVED*** get; set; ***REMOVED***
        public int FontSize ***REMOVED*** get; set; ***REMOVED***

        public KeyStyle()
        ***REMOVED***
            if (Default != null)
            ***REMOVED***
                BaseBrush = Default.BaseBrush;
                FaceBrush = Default.FaceBrush;
                SymbolBrush = Default.SymbolBrush;
                Font = Default.Font;
                FontSize = Default.FontSize;
        ***REMOVED***
    ***REMOVED***

        public static KeyStyle Default ***REMOVED*** get; set; ***REMOVED*** = new KeyStyle()
        ***REMOVED***
            BaseBrush = Brushes.Gray,
            SymbolBrush = Brushes.Black,
            FaceBrush = Brushes.WhiteSmoke,
            Font = "Myriad",
            FontSize = 15
    ***REMOVED***;
***REMOVED***
***REMOVED***