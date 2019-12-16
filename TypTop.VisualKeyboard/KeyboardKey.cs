using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public abstract class KeyboardKey
    {
        private KeyStyle _style;

        protected KeyboardKey(Key key, Size size, KeyStyle style)
        {
            Key = key;
            Size = size;
            Style = style;
        }

        public Point Point { get; set; }
        public Size Size { get; set; }
        protected Rect Rectangle => new Rect(Point, Size);

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

        public virtual void Render(DrawingContext drawingContext)
        {
            DrawKeyBase(drawingContext);
            DrawKeyFace(drawingContext);
            DrawSymbols(drawingContext);
        }

        public virtual void DrawKeyBase(DrawingContext drawingContext)
        {
            var baseRectangle = new Rect(Point, Size);
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