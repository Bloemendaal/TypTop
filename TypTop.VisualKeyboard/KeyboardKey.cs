***REMOVED***
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyStyleChangedEventArgs
    ***REMOVED***
        public KeyStyle KeyStyle ***REMOVED*** get; ***REMOVED***

        public KeyStyleChangedEventArgs(KeyStyle keyStyle)
        ***REMOVED***
            KeyStyle = keyStyle;
    ***REMOVED***
***REMOVED***

    public abstract class KeyboardKey
    ***REMOVED***
        private KeyStyle _style;
        protected Rect Rectangle ***REMOVED*** get; ***REMOVED***

        public KeyStyle Style
        ***REMOVED***
            get => _style;
            set
            ***REMOVED***
                if (value != _style)
                ***REMOVED***
                    _style = value;
                    OnStyleChanged(new KeyStyleChangedEventArgs(value));
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        public Key Key ***REMOVED*** get; ***REMOVED***

        public event EventHandler<KeyStyleChangedEventArgs> StyleChanged;

        protected KeyboardKey(Key key,Rect rectangle,KeyStyle style)
        ***REMOVED***
            Key = key;
            Rectangle = rectangle;
            Style = style;
    ***REMOVED***

        public virtual void Render(DrawingContext drawingContext)
        ***REMOVED***
            DrawKeyBase(drawingContext);
            DrawKeyFace(drawingContext);
            DrawSymbols(drawingContext);
    ***REMOVED***

        public virtual void DrawKeyBase(DrawingContext drawingContext)
        ***REMOVED***
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
    ***REMOVED***

        public virtual void DrawKeyFace(DrawingContext drawingContext)
        ***REMOVED***
            Rect faceRectangle = Rectangle;
            faceRectangle.Height -= 5;
            
            drawingContext.DrawRoundedRectangle(
                Style.FaceBrush,
                null, 
                faceRectangle,
                5D,
                5D
            );
    ***REMOVED***

        public abstract void DrawSymbols(DrawingContext drawingContext);

        protected virtual void OnStyleChanged(KeyStyleChangedEventArgs e)
        ***REMOVED***
            StyleChanged?.Invoke(this, e);
    ***REMOVED***
***REMOVED***
***REMOVED***