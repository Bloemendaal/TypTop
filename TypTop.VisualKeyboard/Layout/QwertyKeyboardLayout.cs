using System.Windows.Input;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class QwertyKeyboardLayout : KeyboardLayout
    ***REMOVED***
        public QwertyKeyboardLayout()
        ***REMOVED***
            int x = 0;
            int y = 0;

            const int spacedKeyWidth = KeyWidth + KeySpacing;
            const int spacedKeyHeight = KeyHeight + KeySpacing;

            AddKey(Key.Q, x,y);
            AddKey(Key.W, x+=spacedKeyWidth,y);
            AddKey(Key.E, x+=spacedKeyWidth,y);
            AddKey(Key.R, x+=spacedKeyWidth,y);
            AddKey(Key.T, x+=spacedKeyWidth,y);
            AddKey(Key.Y, x+=spacedKeyWidth,y);
            AddKey(Key.U, x+=spacedKeyWidth,y);
            AddKey(Key.I, x+=spacedKeyWidth,y);
            AddKey(Key.O, x+=spacedKeyWidth,y);
            AddKey(Key.P, x+=spacedKeyWidth,y);

            y += spacedKeyHeight;
            x = 10;

            AddKey(Key.A, x, y);
            AddKey(Key.S, x += spacedKeyWidth, y);
            AddKey(Key.D, x += spacedKeyWidth, y);
            AddKey(Key.F, x += spacedKeyWidth, y);
            AddKey(Key.G, x += spacedKeyWidth, y);
            AddKey(Key.H, x += spacedKeyWidth, y);
            AddKey(Key.J, x += spacedKeyWidth, y);
            AddKey(Key.K, x += spacedKeyWidth, y);
            AddKey(Key.L, x += spacedKeyWidth, y);

            y += spacedKeyHeight;
            x = 30;

            AddKey(Key.Z, x, y);
            AddKey(Key.X, x += spacedKeyWidth, y);
            AddKey(Key.C, x += spacedKeyWidth, y);
            AddKey(Key.V, x += spacedKeyWidth, y);
            AddKey(Key.B, x += spacedKeyWidth, y);
            AddKey(Key.N, x += spacedKeyWidth, y);
            AddKey(Key.M, x += spacedKeyWidth, y);

            AddKey(Key.Space, spacedKeyWidth * 3,y + spacedKeyHeight);
    ***REMOVED***
***REMOVED***
***REMOVED***