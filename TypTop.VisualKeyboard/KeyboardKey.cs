using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
***REMOVED***
    public abstract class KeyboardKey
    ***REMOVED***
        protected Rect Rectangle ***REMOVED*** get; ***REMOVED***
        public abstract KeyStyle Style ***REMOVED*** get; set; ***REMOVED***

        public Key Key ***REMOVED*** get; ***REMOVED***

        protected KeyboardKey(Key key,Rect rectangle)
        ***REMOVED***
            Key = key;
            Rectangle = rectangle;
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
***REMOVED***
***REMOVED***