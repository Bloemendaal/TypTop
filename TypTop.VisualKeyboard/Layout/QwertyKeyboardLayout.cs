using System.Windows.Input;

namespace TypTop.VisualKeyboard
{
    public class QwertyKeyboardLayout : KeyboardLayout
    {
        public QwertyKeyboardLayout()
        {
            int x = 0;
            int y = 0;

            const int spacedKeyWidth = KeyWidth + KeySpacing;

            AddNormalKey(Key.Q, x,y);
            AddNormalKey(Key.W, x+=spacedKeyWidth,y);
            AddNormalKey(Key.E, x+=spacedKeyWidth,y);
            AddNormalKey(Key.R, x+=spacedKeyWidth,y);
            AddNormalKey(Key.T, x+=spacedKeyWidth,y);
            AddNormalKey(Key.Y, x+=spacedKeyWidth,y);
            AddNormalKey(Key.U, x+=spacedKeyWidth,y);
            AddNormalKey(Key.I, x+=spacedKeyWidth,y);
            AddNormalKey(Key.O, x+=spacedKeyWidth,y);
            AddNormalKey(Key.P, x+=spacedKeyWidth,y);

            y += spacedKeyWidth;
            x = 10;

            AddNormalKey(Key.A, x, y);
            AddNormalKey(Key.S, x += spacedKeyWidth, y);
            AddNormalKey(Key.D, x += spacedKeyWidth, y);
            AddNormalKey(Key.F, x += spacedKeyWidth, y);
            AddNormalKey(Key.G, x += spacedKeyWidth, y);
            AddNormalKey(Key.H, x += spacedKeyWidth, y);
            AddNormalKey(Key.J, x += spacedKeyWidth, y);
            AddNormalKey(Key.K, x += spacedKeyWidth, y);
            AddNormalKey(Key.L, x += spacedKeyWidth, y);

            y += spacedKeyWidth;
            x = 30;

            AddNormalKey(Key.Z, x, y);
            AddNormalKey(Key.X, x += spacedKeyWidth, y);
            AddNormalKey(Key.C, x += spacedKeyWidth, y);
            AddNormalKey(Key.V, x += spacedKeyWidth, y);
            AddNormalKey(Key.B, x += spacedKeyWidth, y);
            AddNormalKey(Key.N, x += spacedKeyWidth, y);
            AddNormalKey(Key.M, x += spacedKeyWidth, y);
        }
    }
}