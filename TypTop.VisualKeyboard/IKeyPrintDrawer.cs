using System.Windows;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public interface IKeyPrintDrawer
    {
        void Draw(Rect key, DrawingContext drawingContext);
    }
}