namespace TypTop.VisualKeyboard
{
    public class KeyStyleChangedEventArgs
    {
        public KeyStyleChangedEventArgs(KeyStyle keyStyle)
        {
            KeyStyle = keyStyle;
        }

        public KeyStyle KeyStyle { get; }
    }
}