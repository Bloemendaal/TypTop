using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class KeyboardLayout
    {
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;


        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();

        private static readonly Lazy<ColemakKeyboardLayout> LazyAzerty = new Lazy<ColemakKeyboardLayout>();
        private readonly KeyFactory _keyFactory;
        private readonly RowBox _rowBox;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();

        public KeyboardLayout(KeyFactory keyFactory)
        {
            _keyFactory = keyFactory;
            _rowBox = new RowBox();
            Style = KeyStyle.Default;
        }

        public KeyStyle Style { get; set; }
        public static KeyboardLayout Qwerty => LazyQwerty.Value;
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void NextRow()
        {
            _rowBox.NextRow();
        }

        protected void AddKey(Key key)
        {
            KeyboardKey keyboardKey = _keyFactory.CreateKey(key, Style);
            keyboardKey.Point = _rowBox.GetPosition(keyboardKey.Size);

            Keys.Add(key, keyboardKey);
        }

        public void InvalidateKeyStyle()
        {
            foreach (KeyboardKey changedKeyStyle in CustomStyledKeys) changedKeyStyle.Style = Style;
            CustomStyledKeys.Clear();
        }

        public void SetKeyStyle(Key key, KeyStyle keyStyle)
        {
            KeyboardKey keyboardKey = Keys[key];
            keyboardKey.Style = keyStyle;
            CustomStyledKeys.Add(keyboardKey);
        }

        public void Render(DrawingContext drawingContext)
        {
            foreach (KeyboardKey key in Keys.Values) key.Render(drawingContext);
        }
    }
}