using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public abstract class KeyboardKey
    {
        protected Rect Rectangle { get; }
        public abstract KeyStyle Style { get; set; }

        public Key Key { get; }

        protected KeyboardKey(Key key,Rect rectangle)
        {
            Key = key;
            Rectangle = rectangle;
        }

        public virtual void Render(DrawingContext drawingContext)
        {
            DrawKeyBase(drawingContext);
            DrawKeyFace(drawingContext);
            DrawSymbols(drawingContext);
        }

        public virtual void DrawKeyBase(DrawingContext drawingContext)
        {
            Rect baseRectangle = Rectangle;
            baseRectangle.Height -= 5;
            baseRectangle.Y += 5;

            drawingContext.DrawRoundedRectangle(
                Style.BaseBrush,
                null,
                baseRectangle, 
                5D,
                5D
            );
        }

        public virtual void DrawKeyFace(DrawingContext drawingContext)
        {
            Rect faceRectangle = Rectangle;
            faceRectangle.Height -= 5;
            
            drawingContext.DrawRoundedRectangle(
                Style.FaceBrush,
                null, 
                faceRectangle,
                5D,
                5D
            );
        }

        public abstract void DrawSymbols(DrawingContext drawingContext);
    }
}