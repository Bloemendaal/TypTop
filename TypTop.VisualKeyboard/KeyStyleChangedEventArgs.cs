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
}