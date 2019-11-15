using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class KeyStyleChangedEventArgs
    {
        public KeyStyle KeyStyle { get; }

        public KeyStyleChangedEventArgs(KeyStyle keyStyle)
        {
            KeyStyle = keyStyle;
        }
    }

    public abstract class KeyboardKey
    {
        private KeyStyle _style;
        protected Rect Rectangle { get; }

        public KeyStyle Style
        {
            get => _style;
            set
            {
                if (value != _style)
                {
                    _style = value;
                    OnStyleChanged(new KeyStyleChangedEventArgs(value));
                }
            }
        }

        public Key Key { get; }

        public event EventHandler<KeyStyleChangedEventArgs> StyleChanged;

        protected KeyboardKey(Key key,Rect rectangle,KeyStyle style)
        {
            Key = key;
            Rectangle = rectangle;
            Style = style;
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

        protected virtual void OnStyleChanged(KeyStyleChangedEventArgs e)
        {
            StyleChanged?.Invoke(this, e);
        }
    }
}