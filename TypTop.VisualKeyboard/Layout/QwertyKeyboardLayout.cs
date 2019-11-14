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

        }
    }
}