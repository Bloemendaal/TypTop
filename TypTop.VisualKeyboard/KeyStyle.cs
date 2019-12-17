using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class KeyStyle
    {
        public Brush BaseBrush { get; set; }
        public Brush FaceBrush { get; set; }
        public Brush SymbolBrush { get; set; }
        public string Font { get; set; }
        public int FontSize { get; set; }

        public KeyStyle()
        {
            if (Default != null)
            {
                BaseBrush = Default.BaseBrush;
                FaceBrush = Default.FaceBrush;
                SymbolBrush = Default.SymbolBrush;
                Font = Default.Font;
                FontSize = Default.FontSize;
            }
        }

        public static KeyStyle Default { get; set; } = new KeyStyle()
        {
            BaseBrush = Brushes.Gray,
            SymbolBrush = Brushes.Black,
            FaceBrush = Brushes.WhiteSmoke,
            Font = "Myriad",
            FontSize = 15
        };
    }
}