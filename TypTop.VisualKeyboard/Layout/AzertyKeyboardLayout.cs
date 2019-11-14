using System.Windows.Input;

namespace TypTop.VisualKeyboard
{
    public class AzertyKeyboardLayout : KeyboardLayout
    {
        public AzertyKeyboardLayout()
        {
            int x = 0;
            int y = 0;

            const int spacedKeyWidth = KeyWidth + KeySpacing;

            AddNormalKey(Key.A, x, y);
            AddNormalKey(Key.Z, x += spacedKeyWidth, y);
            AddNormalKey(Key.E, x += spacedKeyWidth, y);
            AddNormalKey(Key.R, x += spacedKeyWidth, y);
            AddNormalKey(Key.T, x += spacedKeyWidth, y);
            AddNormalKey(Key.Y, x += spacedKeyWidth, y);

        }
    }
}