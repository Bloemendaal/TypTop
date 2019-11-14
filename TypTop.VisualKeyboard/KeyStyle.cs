using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class KeyStyle
    {
        public Brush BaseBrush { get; set; }
        public Brush FaceBrush { get; set; }
        public Brush SymbolBrush { get; set; }
        public static KeyStyle Default { get; set; } = new KeyStyle()
        {
            BaseBrush = Brushes.Gray,
            SymbolBrush = Brushes.Black,
            FaceBrush = Brushes.WhiteSmoke
        };
    }
}