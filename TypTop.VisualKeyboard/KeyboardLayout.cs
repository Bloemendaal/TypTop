using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
{
    public class KeyboardLayout
    {
        private readonly KeyFactory _keyFactory;
        public KeyStyle Style { get; set; }
        
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();


        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
        public static KeyboardLayout Qwerty => LazyQwerty.Value;

        private static readonly Lazy<AzertyKeyboardLayout> LazyAzerty = new Lazy<AzertyKeyboardLayout>();
        private readonly RowBox _rowBox;
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void NextRow()
        {
            _rowBox.NextRow();
        }
        
        protected void AddKey(Key key)
        {
            var keyboardKey = _keyFactory.CreateKey(key, Style);
            keyboardKey.Point = _rowBox.GetPosition(keyboardKey.Size);

            Keys.Add(key, keyboardKey);
        }

        public KeyboardLayout(KeyFactory keyFactory)
        {
            _keyFactory = keyFactory;
            _rowBox = new RowBox();
            Style = KeyStyle.Default;
        }

        public void InvalidateKeyStyle()
        {
            foreach (var changedKeyStyle in CustomStyledKeys)
            {
                changedKeyStyle.Style = Style;
            }
            CustomStyledKeys.Clear();
        }

        public void SetKeyStyle(Key key, KeyStyle keyStyle)
        {
            var keyboardKey = Keys[key];
            keyboardKey.Style = keyStyle;
            CustomStyledKeys.Add(keyboardKey);
        }

        public void Render(DrawingContext drawingContext)
        {
            foreach (KeyboardKey key in Keys.Values)
            {
                key.Render(drawingContext);
            }
        }
    }
}